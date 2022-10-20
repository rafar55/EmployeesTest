#nullable disable
using EmployeeChallenge.Application.Employees.Dtos;
using EmployeeChallenge.Application.Employees.Services;
using EmployeeChallenges.Web.Extensions;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EmployeeChallenges.Web.Pages;

public partial class EmployeeDetail
{
    [Inject]
    public IEmployeeService EmployeeService { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    [Parameter]
    public int? EmployeeId { get; set; }


    private bool IsEditMode { get; set; } = false;
    private EditEmployeeDto Model { get; set; } = new();

    private async Task HandleFormSubmit()
    {
        await ((IsEditMode)
             ? EmployeeService.UpdateEmployeeAsync(EmployeeId.Value, Model)
             : EmployeeService.AddEmployeeAsync(Model));

        NavigationManager.NavigateTo("/");
    }

    protected override async Task OnInitializedAsync()
    {
        if (EmployeeId.HasValue)
        {
            IsEditMode = true;
            var employeeDb = await EmployeeService.GetByIdAsync(EmployeeId.Value);
            Model = new EditEmployeeDto()
            {
                FirstName = employeeDb.FirstName,
                LastName = employeeDb.LastName,
                HireDate = employeeDb.HireDate,
                Phone = employeeDb.Phone.FormatPhoneNumber(),
                ZipCode = employeeDb.ZipCode,
            };
        }
        await base.OnInitializedAsync();
    }
}