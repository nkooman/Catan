using Catan.Core;

namespace Catan.Services.Abstractions
{
    public interface IGameStateService
    {
        GameState InitializeGameState();
    }
}