$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$sourceDir = Join-Path $root 'PCL'
$objDir = Join-Path $root 'obj'
$utf8 = New-Object System.Text.UTF8Encoding($false)
$fieldCount = 0
$methodCount = 0
foreach ($file in (Get-ChildItem -LiteralPath $objDir -Recurse -File -Filter '*.g.cs')) {
    $typeName = $file.Name -replace '\.g\.cs$', ''
    $sourceFile = Join-Path $sourceDir ($typeName + '.xaml.cs')
    if (-not (Test-Path -LiteralPath $sourceFile)) { continue }
    $sourceText = [System.IO.File]::ReadAllText($sourceFile)
    $generatedText = [System.IO.File]::ReadAllText($file.FullName)
    $names = [regex]::Matches($sourceText, 'AccessedThroughProperty\("([^"]+)"\)') | ForEach-Object { $_.Groups[1].Value } | Sort-Object -Unique
    foreach ($name in $names) {
        $pattern = '(?m)^(?:[ \t]*\[[^\r\n]*\][ \t]*\r?\n)*[ \t]*(?:public|internal|private)\s+[^\r\n;]+\s+' + [regex]::Escape($name) + ';[ \t]*(?:\r?\n|$)'
        $matches = [regex]::Matches($generatedText, $pattern)
        $fieldCount += $matches.Count
        $generatedText = [regex]::Replace($generatedText, $pattern, '')
    }
    if ($sourceText.Contains('_CreateDelegate(')) {
        $pattern = '(?m)^(?:[ \t]*\[[^\r\n]*\][ \t]*\r?\n)*[ \t]*internal System\.Delegate _CreateDelegate\(System\.Type delegateType, string handler\) \{\r?\n[ \t]*return System\.Delegate\.CreateDelegate\(delegateType, this, handler\);\r?\n[ \t]*\}[ \t]*(?:\r?\n|$)'
        $matches = [regex]::Matches($generatedText, $pattern)
        $methodCount += $matches.Count
        $generatedText = [regex]::Replace($generatedText, $pattern, '')
    }
    [System.IO.File]::WriteAllText($file.FullName, $generatedText, $utf8)
}
Write-Output "RemovedFields=$fieldCount RemovedMethods=$methodCount"