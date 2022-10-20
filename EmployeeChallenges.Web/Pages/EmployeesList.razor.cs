using Microsoft.AspNetCore.Components;
using EmployeeChallenge.Core.Models;
using EmployeeChallenge.Application.Employees.Services;
using System.Timers;
using Timer = System.Timers.Timer;

namespace EmployeeChallenges.Web.Pages;

public partial class EmployeesList
{
    //for search debounce
    private Timer _timer;

    [Inject]
    private IEmployeeService EmployeeService { get; set; } = default!;

    private Employee[] employees { get; set; } = Array.Empty<Employee>();
    private bool Loading { get; set; } = true;
    private string SearchText { get; set; } = string.Empty;
    private (string SortColumn, bool ascending) SortConfiguration { get; set; } = ("CreatedAt", false);

    protected override async Task OnInitializedAsync()
    {
        await LoadEmployees();
        Loading = false;
    }

    private async Task OnInput(ChangeEventArgs e)
    {

        SearchText = ((string?)e.Value) ?? string.Empty;

        //We nee to apply a 300 milisecons debounce
        //in order to preven multiple unnecesary db calls
        DisposeTimer();
        _timer = new Timer(300);
        _timer.Elapsed += TimerElapsed_TickAsync;
        _timer.Enabled = true;
        _timer.Start();
    }

    private async void TimerElapsed_TickAsync(object? sender, ElapsedEventArgs e)
    {
        DisposeTimer();
        await InvokeAsync(async () =>
        {
            await LoadEmployees();
            StateHasChanged();
        });
    }

    private async Task OnOrderBySelected(ChangeEventArgs e)
    {
        if (e.Value is null)
        {
            SortConfiguration = ("Name", true);
            await LoadEmployees();
            return;
        }

        var orderByValue = int.Parse((string)e.Value);
        SortConfiguration = orderByValue switch
        {
            1 => ("Name", true),
            2 => ("Name", false),
            3 => ("HireDate", true),
            4 => ("HireDate", false),
            5 => ("CreatedAt", true),
            6 => ("CreatedAt", false),
            _ => ("Name", true)
        };
        await LoadEmployees();
    }

    private async Task LoadEmployees()
    {
        var data = await EmployeeService.GetEmployeesAsync(SearchText, SortConfiguration.SortColumn, SortConfiguration.ascending);
        employees = data.ToArray();
    }

    private async Task HandleDelete(int id)
    {
        await EmployeeService.DeleteAsync(id);
        await LoadEmployees();
    }

    private void DisposeTimer()
    {
        _timer?.Stop();
        _timer?.Dispose();
    }

}