using AutoMapper;
using FPCMMS.Application.Contracts.Generic;
using FPCMMS.Application.Exceptions;
using FPCMMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCMMS.Application.Features.Weapon.NotifyComands
{
    public class DeleteNotifyCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteNotifyWeaponCommandHandler : IRequestHandler<DeleteNotifyCommand>
    {
        private readonly IGenericRepository<Notify> _notifyWeaponRepository;
        private readonly IMapper _mapper;
        public DeleteNotifyWeaponCommandHandler(IGenericRepository<Notify> genericRepository, IMapper mapper)
        {
            _notifyWeaponRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteNotifyCommand request, CancellationToken cancellationToken)
        {
            var notifyWeaponToDelete = await _notifyWeaponRepository.GetByIdAsync(request.Id);
            if (notifyWeaponToDelete == null)
            {
                throw new ApiException(nameof(Notify), request.Id);
            }
            await _notifyWeaponRepository.DeleteAsync(notifyWeaponToDelete);
            return Unit.Value;

        }
    }

}
