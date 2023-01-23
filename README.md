# dotnet terraform registry

# Introduction

The purpose of this repository is to build a dotnet implementation of the following terraform internal protocols:

* Remote service discovery
* Module registry
* Provider network mirror

# Remote service discovery

The purpose of this endpoint is to allow terraform to discover which services are provided by the host it's querying.

Terraform docs here: https://developer.hashicorp.com/terraform/internals/provider-registry-protocol

# Module registry

Privately host terraform modules, as an alternative to using local paths or git repos as the module source.

# Hosting

The goal is to provide various configuration extension methods to allow this library to be injected into either an aspnet core web app, or Azure function app, with minimal effort.

# Observability

Various observability hooks so that monitoring solutions such as Application Insights could be used to gather usage information via custom events.


# Distribution

Public nuget packages and injected into your application using builder extensions.

# Configuration

Builder extensions with a default configuration set 'out-of-the-box' for a quick start implementation.

# Priorities

Priorities are as follows:

* Remote service discovery
* Module registry
* aspnetcore web app configuration extension methods
* Azure blob storage for module packages

