// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  apijks: 'https://localhost:5001/api', //dev
  // apijks: 'http://cptsvs531:5000/api-jks/api', //production
  api: 'http://cptsvs531:5000/api-check-sheet/api',
};

// apijks: 'http://cptsvs531:5000/api_jks/api',
// apijks: 'http://cptsvs52t/api_jks/api', //test
// apijks: 'https://localhost:5001/api',

//ng build --base-href=/jkssystem/    /// ระบุชื่อโฟลเดอร์ ให้ตรงกับบน Server ที่จะวาง