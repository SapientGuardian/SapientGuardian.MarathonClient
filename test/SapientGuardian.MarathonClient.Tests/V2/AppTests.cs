using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using SapientGuardian.MarathonClient.Implementations.V2;

namespace SapientGuardian.MarathonClient.Tests.V2
{
    public class AppTests
    {
        const string appJson = @"{	
		""id"": ""/org/prod/frob"",
		""cmd"": null,
		""args"": null,
		""user"": null,
		""env"": {
			""foo"": ""bar"",
			""baz"": ""boo"",
		},
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
				""image"": ""docker-registry.noobcorp.com/orgx/frob:0.1.94"",
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
			""HAPROXY_0_VHOST"": ""frob.noobcorp.com""
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
		""deployments"": [],
		""tasks"": [{
			""id"": ""org_prod_frob.b8e6dfcc-d44c-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S5"",
			""host"": ""m1-slave-2.noobcorp.com"",
			""startedAt"": ""2017-01-06T20:17:10.502Z"",
			""stagedAt"": ""2017-01-06T20:14:26.612Z"",
			""ports"": [2911],
			""version"": ""2016-12-21T19:58:01.436Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.3"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-09T20:26:43.823Z"",
				""lastFailure"": null,
				""lastSuccess"": ""2017-01-24T22:30:32.472Z"",
				""lastFailureCause"": null,
				""taskId"": ""org_prod_frob.b8e6dfcc-d44c-11e6-a31e-a2fc7f3e52f4""
			}]
		},
		{
			""id"": ""org_prod_frob.c7576882-d6f3-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S12"",
			""host"": ""m1-slave-11.noobcorp.com"",
			""startedAt"": ""2017-01-10T05:17:13.175Z"",
			""stagedAt"": ""2017-01-10T05:15:19.118Z"",
			""ports"": [9354],
			""version"": ""2017-01-07T16:47:18.750Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.4"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-10T05:17:33.221Z"",
				""lastFailure"": null,
				""lastSuccess"": ""2017-01-24T22:30:49.434Z"",
				""lastFailureCause"": null,
				""taskId"": ""org_prod_frob.c7576882-d6f3-11e6-a31e-a2fc7f3e52f4""
			}]
		},
		{
			""id"": ""org_prod_frob.b8589d09-d2d9-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S0"",
			""host"": ""m1-slave-25.noobcorp.com"",
			""startedAt"": ""2017-01-05T00:01:29.847Z"",
			""stagedAt"": ""2017-01-04T23:58:42.394Z"",
			""ports"": [61440],
			""version"": ""2016-12-21T19:58:01.436Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.4"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-09T20:26:43.865Z"",
				""lastFailure"": null,
				""lastSuccess"": ""2017-01-24T22:30:32.472Z"",
				""lastFailureCause"": null,
				""taskId"": ""org_prod_frob.b8589d09-d2d9-11e6-a31e-a2fc7f3e52f4""
			}]
		},
		{
			""id"": ""org_prod_frob.ccda7550-d6f1-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S16"",
			""host"": ""m1-slave-18.noobcorp.com"",
			""startedAt"": ""2017-01-10T05:03:49.332Z"",
			""stagedAt"": ""2017-01-10T05:01:09.371Z"",
			""ports"": [7136],
			""version"": ""2017-01-07T16:47:18.750Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.10"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-10T05:04:12.794Z"",
				""lastFailure"": null,
				""lastSuccess"": ""2017-01-24T22:30:49.434Z"",
				""lastFailureCause"": null,
				""taskId"": ""org_prod_frob.ccda7550-d6f1-11e6-a31e-a2fc7f3e52f4""
			}]
		},
		{
			""id"": ""org_prod_frob.eb35e70d-d44c-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S3"",
			""host"": ""m1-slave-1.noobcorp.com"",
			""startedAt"": ""2017-01-06T20:20:10.481Z"",
			""stagedAt"": ""2017-01-06T20:15:51.017Z"",
			""ports"": [41601],
			""version"": ""2016-12-21T19:58:01.436Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.2"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-09T20:26:43.804Z"",
				""lastFailure"": null,
				""lastSuccess"": ""2017-01-24T22:30:32.472Z"",
				""lastFailureCause"": null,
				""taskId"": ""org_prod_frob.eb35e70d-d44c-11e6-a31e-a2fc7f3e52f4""
			}]
		},
		{
			""id"": ""org_prod_frob.f5eec240-d6f7-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S26"",
			""host"": ""m1-slave-19.noobcorp.com"",
			""startedAt"": ""2017-01-10T05:45:17.008Z"",
			""stagedAt"": ""2017-01-10T05:45:15.271Z"",
			""ports"": [33077],
			""version"": ""2017-01-07T16:47:18.750Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.2"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-10T05:45:35.341Z"",
				""lastFailure"": null,
				""lastSuccess"": ""2017-01-24T22:30:49.434Z"",
				""lastFailureCause"": null,
				""taskId"": ""org_prod_frob.f5eec240-d6f7-11e6-a31e-a2fc7f3e52f4""
			}]
		},
		{
			""id"": ""org_prod_frob.2a87e12c-d5df-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S6"",
			""host"": ""m1-slave-3.noobcorp.com"",
			""startedAt"": ""2017-01-08T20:15:16.038Z"",
			""stagedAt"": ""2017-01-08T20:15:14.935Z"",
			""ports"": [27194],
			""version"": ""2017-01-07T16:47:18.750Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.7"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-09T20:27:00.929Z"",
				""lastFailure"": ""2017-01-09T20:26:43.800Z"",
				""lastSuccess"": ""2017-01-24T22:30:49.433Z"",
				""lastFailureCause"": ""ConnectionAttemptFailedException: Connection attempt to m1-slave-3.noobcorp.com:27194 failed"",
				""taskId"": ""org_prod_frob.2a87e12c-d5df-11e6-a31e-a2fc7f3e52f4""
			}]
		},
		{
			""id"": ""org_prod_frob.c757b6a4-d6f3-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S15"",
			""host"": ""m1-slave-17.noobcorp.com"",
			""startedAt"": ""2017-01-10T05:18:49.174Z"",
			""stagedAt"": ""2017-01-10T05:15:19.119Z"",
			""ports"": [18722],
			""version"": ""2017-01-07T16:47:18.750Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.10"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-10T05:18:53.348Z"",
				""lastFailure"": null,
				""lastSuccess"": ""2017-01-24T22:30:49.434Z"",
				""lastFailureCause"": null,
				""taskId"": ""org_prod_frob.c757b6a4-d6f3-11e6-a31e-a2fc7f3e52f4""
			}]
		},
		{
			""id"": ""org_prod_frob.0dd3dad1-d6f8-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S27"",
			""host"": ""m1-slave-8.noobcorp.com"",
			""startedAt"": ""2017-01-10T05:45:57.217Z"",
			""stagedAt"": ""2017-01-10T05:45:55.360Z"",
			""ports"": [40737],
			""version"": ""2017-01-07T16:47:18.750Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.2"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-10T05:46:15.435Z"",
				""lastFailure"": null,
				""lastSuccess"": ""2017-01-24T22:30:49.434Z"",
				""lastFailureCause"": null,
				""taskId"": ""org_prod_frob.0dd3dad1-d6f8-11e6-a31e-a2fc7f3e52f4""
			}]
		},
		{
			""id"": ""org_prod_frob.144610cb-d4f9-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S7"",
			""host"": ""m1-slave-6.noobcorp.com"",
			""startedAt"": ""2017-01-07T16:48:15.982Z"",
			""stagedAt"": ""2017-01-07T16:48:13.347Z"",
			""ports"": [22445],
			""version"": ""2016-12-21T19:58:01.436Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.4"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-09T20:26:43.804Z"",
				""lastFailure"": null,
				""lastSuccess"": ""2017-01-24T22:30:32.472Z"",
				""lastFailureCause"": null,
				""taskId"": ""org_prod_frob.144610cb-d4f9-11e6-a31e-a2fc7f3e52f4""
			}]
		},
		{
			""id"": ""org_prod_frob.37bc6bab-d6f7-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S25"",
			""host"": ""m1-slave-4.noobcorp.com"",
			""startedAt"": ""2017-01-10T05:42:44.997Z"",
			""stagedAt"": ""2017-01-10T05:39:56.174Z"",
			""ports"": [48561],
			""version"": ""2017-01-07T16:47:18.750Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.4"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-10T05:42:55.202Z"",
				""lastFailure"": null,
				""lastSuccess"": ""2017-01-24T22:30:49.434Z"",
				""lastFailureCause"": null,
				""taskId"": ""org_prod_frob.37bc6bab-d6f7-11e6-a31e-a2fc7f3e52f4""
			}]
		},
		{
			""id"": ""org_prod_frob.49ae71b3-d450-11e6-a31e-a2fc7f3e52f4"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S8"",
			""host"": ""m1-slave-7.noobcorp.com"",
			""startedAt"": ""2017-01-06T20:43:54.355Z"",
			""stagedAt"": ""2017-01-06T20:39:58.003Z"",
			""ports"": [16238],
			""version"": ""2016-12-21T19:58:01.436Z"",
			""ipAddresses"": [{
				""ipAddress"": ""172.17.0.4"",
				""protocol"": ""IPv4""
			}],
			""appId"": ""/org/prod/frob"",
			""healthCheckResults"": [{
				""alive"": true,
				""consecutiveFailures"": 0,
				""firstSuccess"": ""2017-01-09T20:26:43.872Z"",
				""lastFailure"": null,
				""lastSuccess"": ""2017-01-24T22:30:32.472Z"",
				""lastFailureCause"": null,
				""taskId"": ""org_prod_frob.49ae71b3-d450-11e6-a31e-a2fc7f3e52f4""
			}]
		}],
		""lastTaskFailure"": {
			""appId"": ""/org/prod/frob"",
			""host"": ""m1-slave-14.noobcorp.com"",
			""message"": ""Task was killed since health check failed. Reason: ConnectionAttemptFailedException: Connection attempt to m1-slave-14.noobcorp.com:27573 failed"",
			""state"": ""TASK_KILLED"",
			""taskId"": ""org_prod_frob.c767233f-d6f7-11e6-a31e-a2fc7f3e52f4"",
			""timestamp"": ""2017-01-10T05:45:34.581Z"",
			""version"": ""2017-01-07T16:47:18.750Z"",
			""slaveId"": ""944a70bf-2d9a-4735-9988-76139775ee2c-S24""
		}
	}
";
        [Fact]
        void ParsesId()
        {
            var app = new App(appJson);
            app.Id.Should().Be("/org/prod/frob");
        }

        [Fact]
        void ParsesInstances()
        {
            var app = new App(appJson);
            app.Instances.Should().Be(12);
        }

        [Fact]
        void SetsInstances()
        {
            var app = new App(appJson);
            app.Instances = 2;
            app.Instances.Should().Be(2);
        }

        [Fact]
        void ParsesEnv()
        {
            var app = new App(appJson);
            app.Env["foo"].Should().Be("bar");
            app.Env["baz"].Should().Be("boo");
        }

        [Fact]
        void SetsEnv()
        {
            var app = new App(appJson);            
            app.Env["test"] = "yes";
            app.Env["test"].Should().Be("yes");
        }

        [Fact]
        void ParsesCpus()
        {
            var app = new App(appJson);
            app.Cpus.Should().Be(2);
        }

        [Fact]
        void SetsCpus()
        {
            var app = new App(appJson);
            app.Cpus = 4;
            app.Cpus.Should().Be(4);
        }

        [Fact]
        void ParsesMem()
        {
            var app = new App(appJson);
            app.Mem.Should().Be(4096);
        }

        [Fact]
        void SetsMem()
        {
            var app = new App(appJson);
            app.Mem = 2048;
            app.Mem.Should().Be(2048);
        }

        [Fact]
        void ParsesLabels()
        {
            var app = new App(appJson);
            app.Labels["HAPROXY_GROUP"].Should().Be("internal");
            app.Labels["HAPROXY_0_VHOST"].Should().Be("frob.noobcorp.com");
        }

        [Fact]
        void ParsesTasksStaged()
        {
            var app = new App(appJson);
            app.TasksStaged.Should().Be(0);
        }

        [Fact]
        void ParsesTasksRunning()
        {
            var app = new App(appJson);
            app.TasksRunning.Should().Be(12);
        }

        [Fact]
        void ParsesTasksHealthy()
        {
            var app = new App(appJson);
            app.TasksHealthy.Should().Be(12);
        }

        [Fact]
        void ParsesTasksUnhealthy()
        {
            var app = new App(appJson);
            app.TasksUnhealthy.Should().Be(0);
        }
    }
}
