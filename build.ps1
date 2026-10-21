[CmdletBinding()]
param(
    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Release'
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest

if ([Environment]::OSVersion.Platform -ne [PlatformID]::Win32NT) {
    throw 'This WPF/.NET Framework 4.8 project requires Windows.'
}

$projectRoot = $PSScriptRoot
$projectFile = Join-Path $projectRoot 'PCL2-Snapshot.csproj'
$requiredInputs = @(
    'PCL.Resources.resx',
    'embedded/Help.zip',
    'embedded/PCLCS.dll',
    'embedded/MeloongCore.dll',
    'tools/FixGeneratedWpf.ps1'
)
foreach ($relativePath in $requiredInputs) {
    $inputPath = Join-Path $projectRoot $relativePath
    if (-not (Test-Path -LiteralPath $inputPath -PathType Leaf)) {
        throw "Required build input is missing: $inputPath"
    }
}
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    throw 'The .NET 10 SDK is required and dotnet was not found.'
}

Push-Location $projectRoot
try {
    & dotnet build $projectFile -c $Configuration --no-incremental -p:EnableWindowsTargeting=true
    if ($LASTEXITCODE -ne 0) {
        throw "dotnet build failed with exit code $LASTEXITCODE"
    }
}
finally {
    Pop-Location
}

$outputDir = Join-Path $projectRoot "bin\$Configuration\net48"
$exePath = Join-Path $outputDir 'Plain Craft Launcher 2.exe'
if (-not (Test-Path -LiteralPath $exePath -PathType Leaf)) {
    throw "Build completed without the expected EXE: $exePath"
}

$artifactRoot = Join-Path $projectRoot 'artifacts'
$artifactDir = Join-Path $artifactRoot $Configuration
New-Item -ItemType Directory -Path $artifactDir -Force | Out-Null
Get-ChildItem -LiteralPath $artifactDir -File | Remove-Item -Force
$buildFiles = Get-ChildItem -LiteralPath $outputDir -File
foreach ($file in $buildFiles) {
    Copy-Item -LiteralPath $file.FullName -Destination $artifactDir -Force
}

$hashLines = @(
    Get-ChildItem -LiteralPath $artifactDir -File |
        Sort-Object Name |
        ForEach-Object {
            $hash = (Get-FileHash -LiteralPath $_.FullName -Algorithm SHA256).Hash.ToLowerInvariant()
            "$hash  $($_.Name)"
        }
)
$manifestPath = Join-Path $artifactDir 'SHA256SUMS.txt'
Set-Content -LiteralPath $manifestPath -Value $hashLines -Encoding Ascii

$archiveName = "PCL2-Snapshot-$Configuration.zip"
$archivePath = Join-Path $artifactRoot $archiveName
Compress-Archive -Path (Join-Path $artifactDir '*') -DestinationPath $archivePath -Force
$archiveHash = (Get-FileHash -LiteralPath $archivePath -Algorithm SHA256).Hash.ToLowerInvariant()
Set-Content -LiteralPath ($archivePath + '.sha256') -Value "$archiveHash  $archiveName" -Encoding Ascii

Write-Output "EXE: $exePath"
Write-Output "Archive: $archivePath"
Write-Output "SHA256: $archiveHash"
