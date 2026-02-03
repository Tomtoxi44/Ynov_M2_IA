# TimeTravel Agency - Webapp Interactive

> Webapp pour une agence de voyage temporel fictive, développée avec Blazor Server .NET 9.

![TimeTravel Agency](https://images.unsplash.com/photo-1451187580459-43490279c0fa?w=800&q=80)

## Description

TimeTravel Agency est une application web interactive permettant aux utilisateurs de :
- Découvrir trois destinations temporelles uniques
- Interagir avec un assistant IA conversationnel
- Trouver leur voyage idéal grâce à un quiz personnalisé
- Réserver leur aventure à travers le temps

## Stack Technique

- **Framework** : Blazor Server (.NET 9)
- **Langage** : C# 13
- **Styling** : CSS personnalisé (Dark theme luxueux)
- **Fonts** : Inter (Google Fonts)
- **Architecture** : Component-based avec services injectés

## Features

### Page d'accueil
- Hero section immersive avec image de fond
- Présentation des 3 destinations en cards interactives
- Section "Pourquoi nous choisir"
- Call-to-action vers la réservation

### Galerie des destinations
- **Paris 1889** - Belle Époque, Tour Eiffel, Exposition Universelle
- **Crétacé -65M** - Dinosaures, nature préhistorique, safari sécurisé
- **Florence 1504** - Renaissance, Michel-Ange, Léonard de Vinci

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
- Transitions fluides entre les pages
- Micro-interactions sur les boutons

## Structure du projet

```
TimeTravelAgency/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor      # Layout principal
│   │   ├── NavBar.razor          # Navigation
│   │   ├── Footer.razor          # Pied de page
│   │   └── ChatWidget.razor      # Chatbot IA
│   ├── Pages/
│   │   ├── Home.razor            # Page d'accueil
│   │   ├── Destinations.razor    # Liste/détail destinations
│   │   ├── Quiz.razor            # Quiz personnalisé
│   │   └── ReservationPage.razor # Formulaire réservation
│   └── Shared/
│       └── DestinationCard.razor # Composant card réutilisable
├── Models/
│   ├── Destination.cs            # Modèle destination
│   ├── Reservation.cs            # Modèle réservation
│   ├── ChatMessage.cs            # Modèle message chat
│   └── QuizQuestion.cs           # Modèle quiz
├── Services/
│   ├── DestinationService.cs     # Service destinations
│   ├── ReservationService.cs     # Service réservations
│   ├── ChatService.cs            # Service chatbot IA
│   └── QuizService.cs            # Service quiz
└── wwwroot/
    ├── css/app.css               # Styles CSS complets
    └── js/animations.js          # Animations scroll
```

## Installation

### Prérequis
- .NET 9 SDK ou supérieur
- Visual Studio 2022 / VS Code avec extension C#

### Lancement

```bash
# Cloner le repository
git clone <url-du-repo>
cd TimeTravelAgency

# Restaurer les packages
dotnet restore

# Lancer l'application
dotnet run
```

L'application sera accessible sur `http://localhost:5222`

## Configuration du Chatbot IA

### Option 1 : Mistral AI (recommandé)
1. Créer un compte sur [console.mistral.ai](https://console.mistral.ai)
2. Générer une clé API
3. Ajouter dans `appsettings.json` :
```json
{
  "ChatApi": {
    "Provider": "mistral",
    "ApiKey": "votre-clé-api"
  }
}
```

### Option 2 : Groq (gratuit, rapide)
1. Créer un compte sur [console.groq.com](https://console.groq.com)
2. Générer une clé API
3. Configurer dans `appsettings.json` avec `"Provider": "groq"`

### Option 3 : OpenAI
1. Utiliser une clé API OpenAI
2. Configurer avec `"Provider": "openai"`

### Mode Fallback
Sans clé API configurée, le chatbot fonctionne avec des réponses pré-programmées intelligentes couvrant les principales questions des utilisateurs.

## IA Utilisées

| Outil | Usage |
|-------|-------|
| GitHub Copilot (Claude 4.5 Sonnet) | Génération du code complet |
| Mistral AI / Groq / OpenAI | Chatbot conversationnel |
| Unsplash | Images libres de droits |

## Design

Le design suit une esthétique **dark mode luxueuse** avec :
- Palette sombre (#0a0a0f, #12121a, #1a1a24)
- Accents dorés (#c9a962)
- Typographie Inter (Google Fonts)
- Bordures subtiles et ombres douces
- Animations fluides (0.3-0.5s)

## Responsive

L'application est entièrement responsive :
- Desktop : Layout complet avec sidebar
- Tablet : Grille adaptée
- Mobile : Navigation hamburger, layout en colonne

## Déploiement

### Azure App Service
```bash
dotnet publish -c Release
# Déployer le dossier publish sur Azure
```

### Docker
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0
COPY publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "TimeTravelAgency.dll"]
```

## Licence

Projet pédagogique - M2 Digital & IA - Ynov 2026

---

**Développé avec Blazor Server .NET 9 et GitHub Copilot**
