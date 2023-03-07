# Repro Steps
- `cd ./appshell` and run `npm i` and then `npm run build`
- `cd ../SuperCoolApp.Ui` and run `dotnet build`
- `cd ../Layout.Ui` and run `dotnet build`
- `cd ../piral~/SuperCoolApp.Ui` and run `npm start`

#  Problem
- If `SuperCoolApp.Ui\Pages\SecretPage.razor` is opened the authentication process runs and leaves the user on page `http://localhost:1234/authentication/http://localhost:1234/`. (There seems to be a redirect issue).
- On the page `SuperCoolApp.Ui\Pages\CascadingAuthStatePage.razor` the username should be shown. It seems like the `CascadingAuthenticationState`'s value from `Layout.Ui\App.razor` does not reach the component.