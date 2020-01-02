
module.exports = {

  globals: { 'ts-jest': { tsConfig: 'tsconfig.json' }  },

  moduleFileExtensions: [ "ts", "js" ],

  testEnvironment: "node",

  testRegex: ".*\\.test\\.ts",

  transform: { "^.+\\.(ts|tsx)$": "ts-jest" },

};
