# fractalize-dotnet-ddd

[![CI](https://github.com/dev-cracks/fractalize-dotnet-ddd/actions/workflows/ci.yml/badge.svg)](https://github.com/dev-cracks/fractalize-dotnet-ddd/actions/workflows/ci.yml)
[![CodeQL](https://github.com/dev-cracks/fractalize-dotnet-ddd/actions/workflows/codeql.yml/badge.svg)](https://github.com/dev-cracks/fractalize-dotnet-ddd/actions/workflows/codeql.yml)
[![OpenSSF Scorecard](https://api.scorecard.dev/projects/github.com/dev-cracks/fractalize-dotnet-ddd/badge)](https://scorecard.dev/viewer/?uri=github.com/dev-cracks/fractalize-dotnet-ddd)
[![Latest release](https://img.shields.io/github/v/release/dev-cracks/fractalize-dotnet-ddd?sort=semver)](https://github.com/dev-cracks/fractalize-dotnet-ddd/releases)
[![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4.svg?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/download/dotnet/10.0)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Conventional Commits](https://img.shields.io/badge/Conventional%20Commits-1.0.0-fe5196.svg?logo=conventionalcommits&logoColor=white)](https://www.conventionalcommits.org/en/v1.0.0/)

> **Domain-Driven Design shared kernel for .NET**: base classes for entities, aggregate roots, value
> objects and domain events, repository and unit-of-work contracts, date ranges and an audit log
> processor, used by the Fractalize services.

## 📦 What's included

| Area | Types |
| --- | --- |
| Entities and aggregates | `EntityBase<TId>`, `AggregateRootBase<TId>`, `DomainEventBase` |
| Value objects | `ValueObjectBase`, `DateRange` (`ValueObjectLegacyBase` is obsolete) |
| Persistence contracts | `IReadRepository<T, TId>`, `IRepository<T, TId>`, `IUnitOfWorkBase` |
| Audit | `IAuditLogProcessor`, `IAuditRepository`, `IClockStamp`, `AuditLogProcessorConfigurator` |

The code lives in [`Src/SharedKernel/Fractalize.Ddd`](Src/SharedKernel/Fractalize.Ddd) and targets .NET 10.

```csharp
// Registers the audit log processor; replace IAuditRepository / IClockStamp with your own before or after.
services.ConfigureAuditLogProccesor();
```

## 🛡️ Standards

- [Engineering standards](docs/engineering-standards.md): file-scoped namespaces, no unused code,
  minimum 80 % line coverage, Options pattern and fluent configurators.
- Conventional Commits, protected `main`, signed commits and automated releases, as described in
  [`CONTRIBUTING.md`](CONTRIBUTING.md).

## 🤝 Contributing

Read [`CONTRIBUTING.md`](CONTRIBUTING.md) before opening a pull request, and report vulnerabilities
privately as described in [`SECURITY.md`](SECURITY.md).

## 📄 License

[MIT](LICENSE) © Dev Cracks
