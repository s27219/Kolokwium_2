using Kolokwium2.Data;
using Kolokwium2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<GetCharacterDto?> GetCharacterInfo(int characterId)
    {
        var character = await _context.Characters
            .Include(c => c.CharacterTitles)
            .ThenInclude(ct => ct.Title)
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Where(c => c.Id == characterId)
            .FirstOrDefaultAsync();
            
        if (character == null)
        {
            return null;
        }

        return new GetCharacterDto
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = character.Backpacks.Select(b => new GetBackpackItemsDto
            {
                ItemName = b.Item.Name,
                ItemWeight = b.Item.Weight,
                Amount = b.Amount
            }).ToList(),
            Titles = character.CharacterTitles.Select(ct => new GetTitleDto()
            {
                Title = ct.Title.Name,
                AquiredAt = ct.AquiredAt
            }).ToList()

        };
    }
    
    /*public async Task<GetPatientDto> GetPatientDetails(int idPatient)
    {
        var patient = await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .Where(p => p.IdPatient == idPatient)
            .FirstOrDefaultAsync();

        if (patient == null)
        {
            return null;
        }

        return new GetPatientDto
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate,
            Prescriptions = patient.Prescriptions
                .OrderBy(pr => pr.DueDate)
                .Select(pr => new GetPrescriptionDto
                {
                    IdPrescription = pr.IdPrescription,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Doctor = new GetDoctorDto
                    {
                        IdDoctor = pr.Doctor.IdDoctor,
                        FirstName = pr.Doctor.FirstName,
                        LastName = pr.Doctor.LastName
                    },
                    Medicaments = pr.PrescriptionMedicaments.Select(pm => new GetMedicamentDto
                    {
                        IdMedicament = pm.IdMedicament,
                        Name = pm.Medicament.Name,
                        Dose = pm.Dose,
                        Description = pm.Medicament.Description
                    }).ToList()
                }).ToList()
        };
    }*/
    
}