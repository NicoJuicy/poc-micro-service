using SchedulerService.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerService.Infrastructure.Clients
{
    public interface INoteServiceClient
    {
        Task<NoteDTO> GetAsync(Guid id);
    }
}
