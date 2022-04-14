# EmergencyLog
 An App to track people and their contacts in case of emergency and tracking of Fire Safety assets and their service record.
 
 ## Rory
 - Get Visual Studio 2022 community edition installed
 - Install SQLite Browser - https://sqlitebrowser.org/
 - Make sure you've got .NET 6 SDK installed - https://dotnet.microsoft.com/en-us/download
 - Clone repo
 - Go to Tools->Nuget Package Manager-> Package Manager Console: then into the terminal type 'update-database'. This should produce an SQLite file called "EmergencyLog.db" in your EmergencyLog.Api root. Open it in the SQLite Browser for a look.
 - Make sure it compliles crtl+shift+B
 - Run it (Big green play button at the top. It should open directly into Swagger where you can querty and test the API. Huge parts of it are probably broken, and it's a WIP.


## To do
- FluentValidation
- Auth
- AutoMapper
- Front end design and technology decisions. I'm keen on React + Typescript, if only because I'm not that great at either and I'd like to use as a learning experience. Not sure exactly how this fits in with you talking about NextJS?
- Decide on a component library, probably either MUI https://mui.com/ or Semantic UI https://react.semantic-ui.com/
- Pagination from API end
- Update only on change for PUT Patch. (API middleware code in validation)
