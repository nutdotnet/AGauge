# Verify valid semver from Ref string, and provide it along with an AssemblyVersion-compatible string as outputs.

# Set to the value provided by github.ref
param([string]$ghRef)

$semVerRegex = "(?<major>0|[1-9]\d*)\.(?<minor>0|[1-9]\d*)\.(?<patch>0|[1-9]\d*)(?:-(?<prerelease>(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+(?<buildmetadata>[0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$"
$matchInfo = [regex]::Match($ghRef, $semVerRegex)

if (!($matchInfo.Success)) {
    Write-Host "Could not find valid semver within ref. string. Given: $ghRef"
    Exit 1
}

$verRes = "ASMVER={0}.{1}.{2}" -f $matchInfo.Groups["major"], $matchInfo.Groups["minor"], $matchInfo.Groups["patch"]
$semVerRes = "SEMVER=" + $matchInfo.Value
$isPr = "ISPRERELEASE=" + $matchInfo.Groups.ContainsKey("prerelease")

echo $verRes >> $env:GITHUB_OUTPUT
echo $semVerRes >> $env:GITHUB_OUTPUT
echo $isPr >> $env:GITHUB_OUTPUT

Write-Host "Result: $verRes, $semVerRes, $isPr"