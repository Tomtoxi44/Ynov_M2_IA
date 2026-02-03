# TimeTravel Agency - Webapp Interactive

Webapp pour une agence de voyage temporel fictive, développée avec Blazor Server .NET 9.

URL de production : https://timetravel-agency-ynov.azurewebsites.net

---

## Description

TimeTravel Agency est une application web interactive permettant aux utilisateurs de :
- Découvrir trois destinations temporelles uniques
- Interagir avec un assistant IA conversationnel
- Trouver leur voyage idéal grâce à un quiz personnalisé
- Réserver leur aventure à travers le temps

---

## Stack Technique

- Framework : Blazor Server (.NET 9)
- Langage : C# 13
- Styling : CSS personnalisé (Dark theme)
- Fonts : Inter (Google Fonts)
- Hébergement : Azure App Service (Plan gratuit F1)
- IA : Mistral AI API

---

## Fonctionnalités

### Page d'accueil
- Hero section immersive avec image de fond
- Présentation des 3 destinations en cards interactives
- Section "Pourquoi nous choisir"
- Call-to-action vers la réservation

### Galerie des destinations
- Paris 1889 : Belle Époque, Tour Eiffel, Exposition Universelle
- Crétacé -65M : Dinosaures, nature préhistorique, safari sécurisé
- Florence 1504 : Renaissance, Michel-Ange, Léonard de Vinci

### Agent conversationnel
- Chatbot IA intégré (widget flottant)
- Support Mistral AI, OpenAI et Groq
- Mode fallback avec réponses intelligentes pré-programmées
- Conseils personnalisés sur les destinations

### Quiz de personnalisation
- 4 questions pour déterminer la destination idéale
- Algorithme de recommandation
- Résultat personnalisé avec explication

### Formulaire de réservation
- Sélection destination + date + nombre de voyageurs
- Validation avec DataAnnotations
- Récapitulatif avec calcul du prix total
- Confirmation de réservation

### Animations
- Fade-in progressif des sections au scroll
- Hover effects sur les cards
- Transitions fluides
- Micro-interactions sur les boutons

---

## Structure du projet

```
TimeTravelAgency/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   ├── NavBar.razor
│   │   ├── Footer.razor
│   │   └── ChatWidget.razor
│   ├── Pages/
│   │   ├── Home.razor
│   │   ├── Destinations.razor
│   │   ├── Quiz.razor
│   │   └── ReservationPage.razor
│   └── Shared/
│       └── DestinationCard.razor
├── Models/
│   ├── Destination.cs
│   ├── Reservation.cs
│   ├── ChatMessage.cs
│   └── QuizQuestion.cs
├── Services/
│   ├── DestinationService.cs
│   ├── ReservationService.cs
│   ├── ChatService.cs
│   └── QuizService.cs
└── wwwroot/
    ├── css/app.css
    └── js/animations.js
```

---

## Installation locale

### Prérequis
- .NET 9 SDK
- Visual Studio 2022 / VS Code

### Lancement

```bash
git clone https://github.com/Tomtoxi44/Ynov_M2_IA.git
cd Ynov_M2_IA/TimeTravelAgency
dotnet restore
dotnet run
```

L'application sera accessible sur http://localhost:5222

---

## Configuration du Chatbot IA

La clé API est stockée de manière sécurisée via User Secrets (développement) ou variables d'environnement (production).

### Développement local

```bash
dotnet user-secrets set "ChatApi:Provider" "mistral"
dotnet user-secrets set "ChatApi:ApiKey" "votre-clé-api"
```

### Production (Azure)

Les variables d'environnement sont configurées dans Azure App Service :
- ChatApi__Provider
- ChatApi__ApiKey

### Providers supportés
- Mistral AI (mistral-small-latest)
- OpenAI (gpt-3.5-turbo)
- Groq (mixtral-8x7b-32768)

Sans clé API, le chatbot fonctionne en mode fallback avec des réponses pré-programmées.

---

## Déploiement

### Azure App Service

```bash
az webapp up --name timetravel-agency-ynov --resource-group rg-timetravel --runtime "DOTNETCORE:9.0" --sku F1 --location "westeurope" --os-type Linux
```

### Configuration des variables d'environnement

```bash
az webapp config appsettings set --name timetravel-agency-ynov --resource-group rg-timetravel --settings ChatApi__Provider="mistral" ChatApi__ApiKey="votre-clé"
```

---

## Design

Le design suit une esthétique dark mode avec :
- Palette sombre (#0a0a0f, #12121a, #1a1a24)
- Accents dorés (#c9a962)
- Typographie Inter
- Bordures subtiles et ombres douces
- Animations fluides (0.3-0.5s)

---

## Responsive

L'application est entièrement responsive :
- Desktop : Layout complet
- Tablet : Grille adaptée
- Mobile : Navigation hamburger, layout en colonne

---

## Technologies et outils utilisés

| Catégorie | Outil |
|-----------|-------|
| Code | Blazor Server .NET 9, C# |
| Assistant code | GitHub Copilot (Claude Sonnet) |
| Chatbot | Mistral AI API |
| Images | Pexels (libres de droits) |
| Hébergement | Azure App Service |
| Versioning | Git / GitHub |

---

## Auteur

Projet pédagogique - M2 Digital & IA - Ynov 2026

---

## Licence

Projet pédagogique - Usage éducatif uniquement
