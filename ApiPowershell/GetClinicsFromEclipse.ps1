# Define the API endpoint
$apiUrl = "http://localhost:8080/getClinics"

$headers = @{
    'Content-Type' = 'application/json'
}

try {
    $response = Invoke-RestMethod -Uri $apiUrl -Method Get -Headers $headers

    foreach($i in $response)
    {
        $i
    }

    # Output the PowerShell object if conversion succeeded
    if ($responseObject) {
        Write-Host "API Response Object:"
        $responseObject
    }
} catch {
    Write-Host "Error: $($_.Exception.Message)"
}

#Add data
$apiAddUrl="http://localhost:8080/saveClinic"
