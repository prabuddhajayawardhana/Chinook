# Blazor Music Application

## Overview
This Blazor project includes several enhancements and new features to improve data management, user interaction, and search capabilities. The following changes have been implemented:

1. **Move Data Retrieval Methods to Separate Classes (Using Dependency Injection)**
2. **Favorite/Unfavorite Tracks and Automatic Playlist Creation**
3. **List User's Playlists in the Left Navbar**
4. **Add Tracks to a Playlist**
5. **Search for Artist Name**

## Changes Made

### 1. Move Data Retrieval Methods to Separate Classes (Using Dependency Injection)
- Extracted data retrieval logic from components.
- Moved logic to dedicated service classes.
- Registered service classes with the dependency injection container.
- Components now request these services as dependencies, resulting in cleaner and more maintainable code.

### 2. Favorite/Unfavorite Tracks and Automatic Playlist Creation
- Implemented functionality to mark tracks as favorite or unfavorite.
- Created an automatic playlist named "My Favorite Tracks" which dynamically updates to include all favorite tracks.

### 3. List User's Playlists in the Left Navbar
- Modified `NavMenu.razor` to display the user's playlists.
- Added logic to update the left navbar when a playlist is added or modified.
- Ensured that the UI reflects changes without requiring a full page reload by using Blazor's event handling and state management.

### 4. Add Tracks to a Playlist
- Completed the dialog for adding tracks to a playlist.
- Allowed users to select an existing playlist or create a new one.
- Integrated dialog with data logic to ensure tracks are correctly added to the specified playlists.

### 5. Search for Artist Name
- Implemented a search feature for artist names.
- Updated the UI to display search results.
- Integrated search logic with data retrieval services.
