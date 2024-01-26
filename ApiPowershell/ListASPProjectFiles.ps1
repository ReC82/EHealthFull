# Get the current directory
$currentDirectory = Get-Location

# Output the current directory
Write-Output "Current Directory: $currentDirectory`n"

# Specify the target folders
$targetFolders = @("Controllers", "Data", "Models", "Pages", "Repositories")

# Recursively get all files under target folders
function Get-TargetFiles {
    param (
        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [Alias("FullName")]
        [string]$Path
    )

    process {
        try {
            $files = Get-ChildItem -LiteralPath $Path -File -Recurse -ErrorAction SilentlyContinue
            foreach ($file in $files) {
                "$($file.FullName.Substring($currentDirectory.Path.Length))"
            }
        } catch {
            Write-Output "Error accessing path: $Path"
        }
    }
}

# Execute the function under target folders
foreach ($targetFolder in $targetFolders) {
    $targetPath = Join-Path -Path $currentDirectory -ChildPath $targetFolder
    Get-TargetFiles -Path $targetPath
}
