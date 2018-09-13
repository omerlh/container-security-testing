# Container Security Testing
This repo demo various security tools that can be used to scan containerized applications for security issues.
All the tools in this repo are free and open source, and you can start using them today.
To get a better understanding of the tools, what are they testing, and why read this blog post.

## Sample App
All the tools are running on a sample app that I created.
The app is a simple dotnet core webapi, with one controller that return all the open positions at [Soluto](https://www.solutotlv.com/), where I'm working.
To run the sample app, run (in `src` folder):
```
dotnet run
```
And open `http://localhost:5000/api/openpositions/` in your browser.

## Tools
You can see the output of the tools under `artifacts` folder, or run them manually as explained below.
### Static Analysis
I'm using [Security Code Scan](https://security-code-scan.github.io/), a static analyzer for dotnet. 
To view the results, open the project in Visual Studio (or Visual Studio for mac) and build the project.
Open `OpenPositionsController`, you should see warnings from the static analysis.
Alternatively, you can just build the project using `dotnet build` and view the warnings.

### Dynamic Analysis
I'm using [OWASP Zaproxy](https://github.com/zaproxy/zaproxy), a security tool by OWASP. To run it:
```
 ./scripts/run_tests.sh
```
When the test execution completed, you can find the report under `glue/report.html`.

### Dependency Scanning
I'm using [Retire.Net](https://github.com/RetireNet/dotnet-retire), a dependency scanner for dotnet. After installing it, run (in `src` folder):
```
dotnet retire
```

### Docker Image Scanning
I'm using [Anchore Engine](https://github.com/anchore/anchore-engine/), a service that scan docker images. To scan the sample app using Anchore:
* Launch anchore by running `docker-compose up -d` in `anchore-engine` folder.
* Scan an image by executing the following POST request:
```
POST /v1/images HTTP/1.1
Host: localhost:8228
Content-Type: application/json
Authorization: Basic YWRtaW46Zm9vYmFy
Cache-Control: no-cache
{
	"tag": "omerlh/open-positions-api:1"
}
```
* Extract the `imageDigest` from the response JSON and use it to get the image vulnerabilities:
```
GET /v1/images/<imageDigest> HTTP/1.1
Host: localhost:8228
Content-Type: application/json
Authorization: Basic YWRtaW46Zm9vYmFy
Cache-Control: no-cache
```
The analyze process might take a while, but when it complete the response will contain all the known vulnerabilities for this image.

### Kubernetes Files Scanning
I'm using `https://kubesec.io/`. Run it using (in `kubernetes` folder):
```
./kubesec deployment.yaml
```