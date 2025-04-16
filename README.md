# 🧩 ASP.NET Core Dependency Injection Demo

<div align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET" />
  <img src="https://img.shields.io/badge/ASP.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" alt="ASP.NET" />
</div>

## 📑 Überblick

Diese Anwendung demonstriert die verschiedenen **Dependency Injection (DI) Lebenszyklus-Optionen** in ASP.NET Core. Das Projekt veranschaulicht anhand eines einfachen Beispiels, wie sich die drei Haupttypen der Dependency Injection (Singleton, Scoped und Transient) in einer ASP.NET Core Anwendung verhalten.

## 🎯 Was wird demonstriert?

Die Anwendung injiziert fünf Service-Instanzen in den HomeController:
- Ein Singleton-Service
- Zwei Transient-Services
- Zwei Scoped-Services

Beim Aufruf der Homepage werden die GUIDs aller Services angezeigt, wodurch das Verhalten der verschiedenen Lebenszyklen sichtbar wird.

## 🌈 Erklärung der Service-Typen

### 💚 Singleton Service

```
"singleton": "a0e0606a-a535-48d0-af47-8b3416d8c15a"
```

> 🔹 **Eine Instanz für die gesamte Anwendung**
> 
> Bei jeder Anfrage und in jeder Controller-Instanz bleibt die ID eines Singleton-Services identisch. Die Instanz wird einmal für die gesamte Anwendungslaufzeit erstellt.
>
> **Anwendungsfall:** Gut für zustandslose Services oder wenn ein gemeinsamer Zustand über die gesamte Anwendung benötigt wird.

### 💙 Transient Services

```
"transient": "9e9b520e-1f5b-44c8-9ff5-ea8db1e1f397"
"transient2": "f6ed469a-0e84-4243-af7e-083098b790a0"
```

> 🔹 **Eine neue Instanz bei jeder Anforderung**
> 
> Transient-Services haben unterschiedliche IDs, selbst wenn sie im selben Controller und innerhalb derselben Anfrage angefordert werden. Jede Injection erzeugt eine neue Instanz.
>
> **Anwendungsfall:** Ideal für leichtgewichtige, zustandslose Services.

### 💜 Scoped Services

```
"scoped": "732e509f-e860-48f2-8402-7b8a71f637eb"
"scoped2": "732e509f-e860-48f2-8402-7b8a71f637eb"
```

> 🔹 **Eine Instanz pro HTTP-Anfrage**
> 
> Scoped-Services haben innerhalb einer HTTP-Anfrage die gleiche ID. Bei einer neuen Anfrage (z.B. Seite neu laden) werden neue Instanzen mit neuen IDs erstellt.
>
> **Anwendungsfall:** Perfekt für Services, die innerhalb einer Anfrage einen gemeinsamen Zustand haben sollen, wie z.B. Datenbankverbindungen.

## 🗂️ Projektstruktur

```
📁 DI-Demo
 ┣ 📁 Controllers
 ┃ ┗ 📄 HomeController.cs     // Controller mit injizierten Services
 ┣ 📁 Services
 ┃ ┣ 📄 ITransientService.cs  // Interface für Transient-Service
 ┃ ┣ 📄 IScopedService.cs     // Interface für Scoped-Service
 ┃ ┣ 📄 ISingletonService.cs  // Interface für Singleton-Service
 ┃ ┣ 📄 TransientService.cs   // Implementierung des Transient-Service
 ┃ ┣ 📄 ScopedService.cs      // Implementierung des Scoped-Service
 ┃ ┗ 📄 SingletonService.cs   // Implementierung des Singleton-Service
 ┣ 📁 Views
 ┃ ┗ 📁 Home
 ┃   ┗ 📄 Index.cshtml        // View zur Anzeige der Service-IDs
 ┣ 📄 Program.cs              // Konfiguration und Service-Registrierung
 ┗ 📄 README.md
```

## 🚀 Verwendung

1. **Klonen Sie das Repository**
   ```bash
   git clone [repository-url]
   ```

2. **Navigieren Sie zum Projektverzeichnis**
   ```bash
   cd di-demo
   ```

3. **Starten Sie die Anwendung**
   ```bash
   dotnet run
   ```

4. **Öffnen Sie im Browser**
   ```
   https://localhost:5001/
   ```

5. **Beobachten Sie die IDs und aktualisieren Sie die Seite mehrmals**

## 🎓 Lernziele

- ✅ Grundlegende Dependency Injection in ASP.NET Core verstehen
- ✅ Unterschiede zwischen Singleton-, Scoped- und Transient-Diensten erkennen
- ✅ Services im Dependency Injection Container registrieren
- ✅ Services in Controllern richtig verwenden

## 📝 Code-Beispiele

### Service-Registrierung in Program.cs

```csharp
// DI Container konfigurieren
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();
```

### Service-Injektion im Controller

```csharp
public class HomeController : Controller
{
    private readonly ISingletonService _singletonService;
    private readonly ITransientService _transientService;
    private readonly ITransientService _transientService2;
    private readonly IScopedService _scopedService;
    private readonly IScopedService _scopedService2;

    public HomeController(
        ISingletonService singletonService,
        ITransientService transientService,
        ITransientService transientService2,
        IScopedService scopedService,
        IScopedService scopedService2)
    {
        _singletonService = singletonService;
        _transientService = transientService;
        _transientService2 = transientService2;
        _scopedService = scopedService;
        _scopedService2 = scopedService2;
    }
    
    // Controller-Actions...
}
```

## 📚 Ressourcen

- [Microsoft Docs: Dependency Injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
- [ASP.NET Core Dependency Injection in Depth](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)

---

## 👩‍💻 Entwickelt von

**[@lady-logic](https://github.com/lady-logic)**
