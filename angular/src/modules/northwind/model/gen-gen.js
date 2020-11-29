const tsGen = require("breeze-entity-generator/tsgen-core");
const fs = require("fs");
const dir = "./model";

if (!fs.existsSync(dir)) {
  fs.mkdirSync(dir);
}

tsGen.generate({
  inputFileName: "metadata.json",
  outputFolder: dir,
  camelCase: true,
  baseClassName: "BaseEntity",
  kebabCaseFileNames: true,
  codePrefix: "Northwind",
});
