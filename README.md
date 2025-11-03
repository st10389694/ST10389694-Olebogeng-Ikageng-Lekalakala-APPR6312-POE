# st10389694 - Gift of the Givers App (GitHub-ready)

This repository is prepared for direct push to GitHub under the user `st10389694`.
It contains a .NET 8.0 web app, tests, CI/CD workflow, Playwright UI tests, JMeter placeholders, and PDF test reports (placeholders).

## Quick start (local)
- Install .NET 8 SDK
- Restore and build:
  ```bash
  dotnet restore
  dotnet build
  ```
- Run the app:
  ```bash
  dotnet run --project GiftOfGiversApp
  ```
- Run tests:
  ```bash
  dotnet test
  ```

## CI/CD
The GitHub Actions workflow is at `.github/workflows/azure-ci-cd.yml`.
Set `AZURE_PUBLISH_PROFILE` in repo secrets to enable deployment to Azure App Service `gift-of-givers-st10389694`.

## Verify deployment
A PowerShell script `verify-deployment.ps1` is included to check the live app and save a short report to `docs/Deployment_Verification_Report.txt`.

