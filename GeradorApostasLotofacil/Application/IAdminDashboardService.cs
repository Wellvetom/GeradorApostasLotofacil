using GeradorApostasLotofacil.DTO;

namespace GeradorApostasLotofacil.Application
{
    public interface IAdminDashboardService
    {
        Task<AdminDashboardViewModel> ObterDashboardAdmin();
    }
}
