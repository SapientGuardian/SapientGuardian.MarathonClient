#SapientGuardian.MarathonClient

## Description
SapientGuardian.MarathonClient is a client library for [Marathon](https://mesosphere.github.io/marathon/), a container orchestration platform for Mesos and DC/OS.  
The API coverage is extremely minimal at this time, exposing only the functionality I need in my other projects, but you may find it useful too.

## How to use it

Call the static SapientGuardian.MarathonClient.ClientFactory.V2Client method with the URL of your V2 Marathon API (e.g. http://marathon.mycluster.local/v2/), and optionally provide an authorization token.
    ```C#
    
    var myClient = SapientGuardian.MarathonClient.ClientFactory.V2Client("http://marathon.mycluster.local/v2/");
    var awesomeApp = await myClient.Apps.get("/myApps/awesomeApp");
    awesomeApp.instances++;
    await myClient.Apps.Update(awesomeApp);
    
    ```  