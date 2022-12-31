using System.Security.Claims;

namespace Ris2022.Data.Models
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            //new Claim("ClaimName", "true")
            // Start AcceptanceTypeController
            new Claim("Index+Details-->Acceptance Types", "false"),
            //new Claim("Details-->Acceptance Types", "false"),
            new Claim("Create-->Acceptance Types", "false"),
            new Claim("Edit-->Acceptance Types", "false"),
            new Claim("Delete-->Acceptance Types", "false"),
            // End AcceptanceTypeController

            // Start ClinicsController
            new Claim("Index+Details-->Clinics", "false"),
            new Claim("Create-->Clinics", "false"),
            new Claim("Edit-->Clinics", "false"),
            new Claim("Delete-->Clinics", "false"),
            // End ClinicsController

            // Start DepartmentsController
            new Claim("Index+Details-->Departments", "false"),
            new Claim("Create-->Departments", "false"),
            new Claim("Edit-->Departments", "false"),
            new Claim("Delete-->Departments", "false"),
            // End DepartmentsController

            // Start MartialstatusController
            new Claim("Index+Details-->MartialStatus", "false"),
            new Claim("Create-->MartialStatus", "false"),
            new Claim("Edit-->MartialStatus", "false"),
            new Claim("Delete-->MartialStatus", "false"),
            // End MartialstatusController
            
            // Start ModalitiesController
            new Claim("Index+Details-->Modalities", "false"),
            new Claim("Create-->Modalities", "false"),
            new Claim("Edit-->Modalities", "false"),
            new Claim("Delete-->Modalities", "false"),
            // End ModalitiesController

            // Start ModalityTypesController
            new Claim("Index+Details-->ModalityTypes", "false"),
            new Claim("Create-->ModalityTypes", "false"),
            new Claim("Edit-->ModalityTypes", "false"),
            new Claim("Delete-->ModalityTypes", "false"),
            // End ModalityTypesController

            // Start NationalitiesController
            new Claim("Index+Details-->Nationalities", "false"),
            new Claim("Create-->Nationalities", "false"),
            new Claim("Edit-->Nationalities", "false"),
            new Claim("Delete-->Nationalities", "false"),
            // End NationalitiesController

            // Start OrdersController
            new Claim("Create-->Orders", "false"),
            new Claim("Index+Details-->Orders", "false"),
            new Claim("Edit-->Orders", "false"),
            new Claim("Delete-->Orders", "false"),
            new Claim("CreateScheduled-->Orders", "false"),
            new Claim("Index+DetailsScheduled-->Orders", "false"),
            new Claim("EditScheduled-->Orders", "false"),
            new Claim("DeleteScheduled-->Orders", "false"),
            // End OrdersController

            // Start OrderTypesController
            new Claim("Index+Details-->OrderTypes", "false"),
            new Claim("Create-->OrderTypes", "false"),
            new Claim("Edit-->OrderTypes", "false"),
            new Claim("Delete-->OrderTypes", "false"),
            // End OrderTypesController

            // Start PatientsController
            new Claim("Index+Details-->Patients", "false"),
            new Claim("Create-->Patients", "false"),
            new Claim("Edit-->Patients", "false"),
            new Claim("Delete-->Patients", "false"),
            // End PatientssController

            // Start PayTypesController
            new Claim("Index+Details-->PayTypes", "false"),
            new Claim("Create-->PayTypes", "false"),
            new Claim("Edit-->PayTypes", "false"),
            new Claim("Delete-->PayTypes", "false"),
            // End PayTypesController

            // Start ProcedureTypesController
            new Claim("Index+Details-->ProcedureTypes", "false"),
            new Claim("Create-->ProcedureTypes", "false"),
            new Claim("Edit-->ProcedureTypes", "false"),
            new Claim("Delete-->ProcedureTypes", "false"),
            // End ProcedureTypesController

            // Start ReasonsController
            new Claim("Index+Details-->Reasons", "false"),
            new Claim("Create-->Reasons", "false"),
            new Claim("Edit-->Reasons", "false"),
            new Claim("Delete-->Reasons", "false"),
            // End ReasonsController

            // Start WorkTypesController
            new Claim("Index+Details-->WorkTypes", "false"),
            new Claim("Create-->WorkTypes", "false"),
            new Claim("Edit-->WorkTypes", "false"),
            new Claim("Delete-->WorkTypes", "false"),
            // End WorkTypesController

            // Start AdministrationController
            new Claim("Index+Details-->Users", "false"),
            new Claim("Create-->Users", "false"),
            new Claim("Edit-->Users", "false"),
            new Claim("ManageClaims-->Users", "false"),
            new Claim("Index+Details-->Roles", "false"),
            new Claim("Create-->Roles", "false"),
            new Claim("Edit-->Roles", "false"),
            new Claim("Delete-->Roles", "false"),
            new Claim("EditUserIn-->Roles", "false"),
            // End AdministrationController
        };
    }
}
