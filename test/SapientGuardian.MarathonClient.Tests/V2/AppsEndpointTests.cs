using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace SapientGuardian.MarathonClient.Tests.V2
{
    public class AppsEndpointTests
    {
        [Fact]
        public async Task GetAllReturnsCorrectly()
        {
            var json = @"{
	""apps"": [{
		""id"": ""/org/prod/frob"",
		""cmd"": null,
		""args"": null,
		""user"": null,
		""instances"": 12,
		""cpus"": 2,
		""mem"": 4096,
		""disk"": 0,
		""executor"": """",
		""constraints"": [[""hostname"",
		""UNIQUE""]],
		""uris"": [],
		""fetch"": [],
		""storeUrls"": [],
		""ports"": [10109],
		""portDefinitions"": [{
			""port"": 10109,
			""protocol"": ""tcp"",
			""labels"": {
				
			}
		}],
		""requirePorts"": false,
		""backoffSeconds"": 1,
		""backoffFactor"": 1.15,
		""maxLaunchDelaySeconds"": 3600,
		""container"": {
			""type"": ""DOCKER"",
			""volumes"": [],
			""docker"": {
				""image"": ""docker-registry.noobcorp.com.com/orgx/frob:0.1.94"",
				""network"": ""BRIDGE"",
				""portMappings"": [{
					""containerPort"": 8080,
					""hostPort"": 0,
					""servicePort"": 10109,
					""protocol"": ""tcp"",
					""labels"": {
						
					}
				}],
				""privileged"": false,
				""parameters"": [{
					""key"": ""entrypoint"",
					""value"": ""bin/frob""
				}],
				""forcePullImage"": false
			}
		},
		""healthChecks"": [{
			""path"": ""/healthcheck"",
			""protocol"": ""HTTP"",
			""portIndex"": 0,
			""gracePeriodSeconds"": 60,
			""intervalSeconds"": 20,
			""timeoutSeconds"": 30,
			""maxConsecutiveFailures"": 2,
			""ignoreHttp1xx"": false
		}],
		""readinessChecks"": [],
		""dependencies"": [],
		""upgradeStrategy"": {
			""minimumHealthCapacity"": 0.5,
			""maximumOverCapacity"": 0.5
		},
		""labels"": {
			""HAPROXY_GROUP"": ""internal"",			
			""HAPROXY_0_MODE"": ""http"",
			""HAPROXY_0_BACKEND_HTTP_HEALTHCHECK_OPTIONS"": ""  option  httpchk GET {healthCheckPath} HTTP/1.1\\r\\nHost:\\ www\n  http-check expect status 200\n""
		},
		""acceptedResourceRoles"": null,
		""ipAddress"": null,
		""version"": ""2017-01-07T16:47:18.750Z"",
		""residency"": null,
		""versionInfo"": {
			""lastScalingAt"": ""2017-01-07T16:47:18.750Z"",
			""lastConfigChangeAt"": ""2016-11-30T18:42:58.971Z""
		},
		""tasksStaged"": 0,
		""tasksRunning"": 12,
		""tasksHealthy"": 12,
		""tasksUnhealthy"": 0,
		""deployments"": []
	},
	{
		""id"": ""/orgb/logstash/hooahh"",
		""cmd"": null,
		""args"": [""-f"",
		""/mnt/mesos/sandbox/hooahh.conf""],
		""user"": null,
		""env"": {
			
		},
		""instances"": 0,
		""cpus"": 2,
		""mem"": 2048,
		""disk"": 1024,
		""executor"": """",
		""constraints"": [],	
		""storeUrls"": [],
		""ports"": [],
		""portDefinitions"": [],
		""requirePorts"": false,
		""backoffSeconds"": 1,
		""backoffFactor"": 1.15,
		""maxLaunchDelaySeconds"": 3600,
		""container"": {
			""type"": ""DOCKER"",
			""volumes"": [],
			""docker"": {
				""image"": ""logstash:2.0"",
				""privileged"": false,
				""parameters"": [],
				""forcePullImage"": false
			}
		},
		""healthChecks"": [],
		""readinessChecks"": [],
		""dependencies"": [],
		""upgradeStrategy"": {
			""minimumHealthCapacity"": 0,
			""maximumOverCapacity"": 1
		},
		""labels"": {
			
		},
		""acceptedResourceRoles"": null,
		""ipAddress"": null,
		""version"": ""2016-09-29T13:20:13.601Z"",
		""residency"": null,
		""versionInfo"": {
			""lastScalingAt"": ""2016-09-29T13:20:13.601Z"",
			""lastConfigChangeAt"": ""2016-08-07T15:06:32.303Z""
		},
		""tasksStaged"": 0,
		""tasksRunning"": 0,
		""tasksHealthy"": 0,
		""tasksUnhealthy"": 0,
		""deployments"": []
	}]
}";
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);

            var WebHostBuilder = new WebHostBuilder().Configure(app =>
            {
                app.Use(async (httpContext, next) =>
                {
                    httpContext.Response.ContentType = "application/json";

                    await httpContext.Response.Body.WriteAsync(jsonBytes, 0, jsonBytes.Length);
                });
            });

            var server = new TestServer(WebHostBuilder);
            var client = server.CreateClient();

            var appsEndpoint = ClientFactory.V2Client(client, "http://marathon.mesos.local/", null).Apps;
            var apps = (await appsEndpoint.GetAll()).ToArray();
            apps.Length.Should().Be(2);
        }


        [Fact]
        public async Task GetApp()
        {
            var json = @"{
    ""app"": {
        ""args"": null,
        ""backoffFactor"": 1.15,
        ""backoffSeconds"": 1,
        ""maxLaunchDelaySeconds"": 3600,
        ""cmd"": ""python toggle.py $PORT0"",
        ""constraints"": [],
        ""container"": null,
        ""cpus"": 0.2,
        ""dependencies"": [],
        ""deployments"": [
            {
                ""id"": ""44c4ed48-ee53-4e0f-82dc-4df8b2a69057""
            }
        ],
        ""disk"": 0.0,
        ""env"": {},
        ""executor"": """",
        ""healthChecks"": [
            {
                ""command"": null,
                ""gracePeriodSeconds"": 5,
                ""intervalSeconds"": 10,
                ""maxConsecutiveFailures"": 3,
                ""path"": ""/health"",
                ""portIndex"": 0,
                ""protocol"": ""HTTP"",
                ""timeoutSeconds"": 10
            },
            {
                ""command"": null,
                ""gracePeriodSeconds"": 5,
                ""intervalSeconds"": 10,
                ""maxConsecutiveFailures"": 6,
                ""path"": ""/machinehealth"",
                ""overridePort"": 3333,
                ""protocol"": ""HTTP"",
                ""timeoutSeconds"": 10
            }
        ],
        ""id"": ""/toggle"",
        ""instances"": 2,
        ""lastTaskFailure"": { // soon only for ?embed=lastTaskFailure
            ""appId"": ""/toggle"",
            ""host"": ""10.141.141.10"",
            ""message"": ""Abnormal executor termination"",
            ""state"": ""TASK_FAILED"",
            ""taskId"": ""toggle.cc427e60-5046-11e4-9e34-56847afe9799"",
            ""timestamp"": ""2014-09-12T23:23:41.711Z"",
            ""version"": ""2014-09-12T23:28:21.737Z""
        },
        ""mem"": 32.0,
        ""ports"": [
            10000
        ],
        ""requirePorts"": false,
        ""storeUrls"": [],
        ""tasks"": [ // soon only for ?embed=tasks
            {
                ""appId"": ""/toggle"",
                ""healthCheckResults"": [
                    {
                        ""alive"": true,
                        ""consecutiveFailures"": 0,
                        ""firstSuccess"": ""2014-09-13T00:20:28.101Z"",
                        ""lastFailure"": null,
                        ""lastSuccess"": ""2014-09-13T00:25:07.506Z"",
                        ""taskId"": ""toggle.802df2ae-3ad4-11e4-a400-56847afe9799""
                    },
                    {
                        ""alive"": true,
                        ""consecutiveFailures"": 0,
                        ""firstSuccess"": ""2014-09-13T00:20:28.101Z"",
                        ""lastFailure"": null,
                        ""lastSuccess"": ""2014-09-13T00:25:07.506Z"",
                        ""taskId"": ""toggle.802df2ae-3ad4-11e4-a400-56847afe9799""
                    }
                ],
                ""host"": ""10.141.141.10"",
                ""id"": ""toggle.802df2ae-3ad4-11e4-a400-56847afe9799"",
                ""ports"": [
                    31045
                ],
                ""stagedAt"": ""2014-09-12T23:28:28.594Z"",
                ""startedAt"": ""2014-09-13T00:24:46.959Z"",
                ""version"": ""2014-09-12T23:28:21.737Z""
            },
            {
                ""appId"": ""/toggle"",
                ""healthCheckResults"": [
                    {
                        ""alive"": true,
                        ""consecutiveFailures"": 0,
                        ""firstSuccess"": ""2014-09-13T00:20:28.101Z"",
                        ""lastFailure"": null,
                        ""lastSuccess"": ""2014-09-13T00:25:07.508Z"",
                        ""taskId"": ""toggle.7c99814d-3ad4-11e4-a400-56847afe9799""
                    },
                    {
                        ""alive"": true,
                        ""consecutiveFailures"": 0,
                        ""firstSuccess"": ""2014-09-13T00:20:28.101Z"",
                        ""lastFailure"": null,
                        ""lastSuccess"": ""2014-09-13T00:25:07.506Z"",
                        ""taskId"": ""toggle.802df2ae-3ad4-11e4-a400-56847afe9799""
                    }
                ],
                ""host"": ""10.141.141.10"",
                ""id"": ""toggle.7c99814d-3ad4-11e4-a400-56847afe9799"",
                ""ports"": [
                    31234
                ],
                ""stagedAt"": ""2014-09-12T23:28:22.587Z"",
                ""startedAt"": ""2014-09-13T00:24:46.965Z"",
                ""version"": ""2014-09-12T23:28:21.737Z""
            }
        ],
        ""tasksRunning"": 2, // soon only for ?embed=counts
        ""tasksHealthy"": 2, // soon only for ?embed=counts
        ""tasksUnhealthy"": 0, // soon only for ?embed=counts
        ""tasksStaged"": 0, // soon only for ?embed=counts
        ""upgradeStrategy"": {
            ""minimumHealthCapacity"": 1.0
        },
        ""uris"": [
            ""http://downloads.mesosphere.com/misc/toggle.tgz""
        ],
        ""user"": null,
        ""version"": ""2014-09-12T23:28:21.737Z"",
        ""versionInfo"": {
            ""lastConfigChangeAt"": ""2014-09-11T02:26:01.135Z"",
            ""lastScalingAt"": ""2014-09-12T23:28:21.737Z""
        }
    }
}";
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);

            var WebHostBuilder = new WebHostBuilder().Configure(app =>
            {
                app.Use(async (httpContext, next) =>
                {
                    httpContext.Response.ContentType = "application/json";

                    await httpContext.Response.Body.WriteAsync(jsonBytes, 0, jsonBytes.Length);
                });
            });

            var server = new TestServer(WebHostBuilder);
            var client = server.CreateClient();

            var appsEndpoint = ClientFactory.V2Client(client, "http://marathon.mesos.local/", null).Apps;
            var appTest = await appsEndpoint.Get("/toggle");
            appTest.Should().NotBeNull();

        }

        // TODO: Tests for Update that verifies "uris" and "version" is stripped
    }
}
