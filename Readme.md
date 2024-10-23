# Leaderboard Management System

This project is a Leaderboard example built using ASP.NET Core.

## Features
- User Registration
- Game Record Management
- Leaderboard with Pagination
- Rank Calculation Based on Scores and Update Time

## Technologies Used
- ASP.NET Core
- Entity Framework Core
- AutoMapper
- SQL Server

## Getting Started
### Prerequisites
- .NET 8.0 SDK
- SQL Server

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/cngthnh22112002/leaderboard.git
    ```

2. Navigate to the project directory:
    ```bash
    cd leaderboard-system
    ```

3. Set up the database connection string in `appsettings.json`:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Your SQL Server Connection String"
    }
    ```

4. Run the migrations to set up the database:
    ```bash
    dotnet ef database update
    ```

5. Run the application:
    ```bash
    dotnet run
    ```

## API Endpoints
### User Management
- **POST** `/api/User/CreateUserWithPlay`
  - Create a new user and initialize user play records for all games.

### Game Record Management
- **POST** `/api/GameRecord/AddGameRecord`
  - Add a new game record and update the user's total points in the leaderboard.

### Leaderboard Management
- **GET** `/api/Leaderboard/GetLeaderboard/{gameId}`
  - Get the leaderboard for a specific game within a specified time range, paginated.

- **GET** `/api/Leaderboard/GetUserRank/{gameId}/{userId}`
  - Get the rank and total points of a specific user in a specific game.

## DTOs
- **CreateUserDto**: Data transfer object for creating a user and initializing game records.
- **CreateGameRecordDto**: Data transfer object for adding a new game record.
- **LeaderboardDTO**: Data transfer object for leaderboard entries.
- **PaginatedLeaderboardDTO**: Data transfer object for paginated leaderboard results.
- **UserRankDTO**: Data transfer object for user rank and total points.

## Services
### LeaderboardService
- `GetLeaderboardAsync`: Retrieves the leaderboard for a specific game within a time range, paginated.
- `GetUserRankAsync`: Retrieves the rank and total points of a specific user in a specific game.

### UserService
- `CreateUserWithPlayForAllGamesAsync`: Creates a user and initializes game records for all current games.

### GameRecordService
- `AddGameRecordAsync`: Adds a new game record and updates the corresponding user's total points and rank.

## Contact
If you have any questions, please contact [cngthnh22112002@gmail.com].
