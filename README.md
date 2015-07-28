# AadGraphHelper
This tool let's you, a developer, create request for AAD Graph API, issue the request and get the response. 
The responses can be viewed in a table format (instead of raw JSON) which makes visualization easier, although 
only simple non-null values are exposed in the table. The requests can be saved as templates that can be opened 
up later, and issued against different tenants. Finally, it also has a filter query builder that can let you 
compose a search for users, convert it into a filter query string that can be issued as a request.

To get started:

1. Create an application in Azure Active Directory (https://manage.windowsazure.com).

  a. Create a web application if you want to store the key and authentication to not require manual entry of credentials. Such an application cannot access all properties (e.g. oauth2PermissionGrants), or perform certain operations (e.g. delete a user).

  b. If you need to perform those operations, create a native application. You will be required to provide user credentials on every authentication, but it will allow administrator operations.

2. Click on the "Releases" tab, download the latest release.

3. Open the AadGraphHelper.exe from the downloaded zip file.

4. Select environment "Production" and click "Add" in the Tenant/Credential tab.

5. Add the credentials for the app that you created in step 1.

6. Click on the "Get Token" button.

7. Now you can select the method e.g. GET), resource (e.g. users) and click "Execute" button. This will issue the very first request. Once it executes successfully, play around and have fun.
