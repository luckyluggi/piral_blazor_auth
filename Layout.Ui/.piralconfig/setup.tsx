import { PiletApi } from "appshell";
type AddScript = (path: string, attrs?: Record<string, string>) => void;

const microfrontendName = "layout";

export default (app: PiletApi, addScript: AddScript) => {
	addScript("_content/Microsoft.Authentication.WebAssembly.Msal/AuthenticationService.js");
};
   
