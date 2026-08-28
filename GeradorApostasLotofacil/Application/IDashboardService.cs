using GeradorApostasLotofacil.DTO;

namespace GeradorApostasLotofacil.Application
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> ObterDashboard(int usuarioId);
    }
}
