[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Membership.MVCGridConfig), "RegisterGrids")]

namespace Membership
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using Membership.Models;
    using Unity;
    using System.Data.Entity;

    public static class MVCGridConfig
    {
        public static void RegisterGrids()
        {
            var isViewer = false;
            if (HttpContext.Current != null && HttpContext.Current.User != null)
            {
                isViewer = HttpContext.Current.User.IsInRole("Viewer");
            }

            MVCGridDefinitionTable.Add("MembersGrid", new MVCGridBuilder<Member>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .WithAdditionalQueryOptionNames("search")
                .AddColumns(cols =>
                {
                    // Add your columns here
                    //cols.Add("View").WithHtmlEncoding(false)
                    //    .WithSorting(false)
                    //    .WithHeaderText(" ")
                    //    .WithValueExpression((p, c) => c.UrlHelper.Action("Details", "Members", new { id = p.Id }))
                    //    .WithValueTemplate("<a href='{Value}' class='btn btn-default' role='button'>View</a>");
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithSorting(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((p, c) => c.UrlHelper.Action("Edit", "Members", new { id = p.Id }))
                        .WithVisibility(!isViewer)
                        .WithValueTemplate("<a href='{Value}' class='btn btn-default' role='button'>Edit</a>");
                    //cols.Add("Delete").WithHtmlEncoding(false)
                    //    .WithSorting(false)
                    //    .WithHeaderText(" ")
                    //    .WithValueExpression((p, c) => c.UrlHelper.Action("Delete", "Members", new { id = p.Id }))
                    //    .WithVisibility(!isViewer)
                    //    .WithValueTemplate("<a href='{Value}' class='btn btn-danger' role='button'>Delete</a>");

                    cols.Add("MemNum")
                        .WithSorting(true)
                        .WithHeaderText("Mem Num")
                        .WithAllowChangeVisibility(true)
                        .WithValueExpression(i => i.MemNum.ToString());
                    cols.Add("Status")
                        .WithSorting(true)
                        .WithFiltering(true)
                        .WithHeaderText("Status")
                        .WithAllowChangeVisibility(true)
                        .WithValueExpression(i => i.Status.Name);
                    cols.Add("LastName")
                        .WithSorting(true)
                        .WithAllowChangeVisibility(true)
                        .WithHeaderText("Last")
                        .WithValueExpression(i => i.LastName);
                    cols.Add("FirstName")
                       .WithSorting(true)
                       .WithHeaderText("First")
                        .WithAllowChangeVisibility(true)
                       .WithValueExpression(i => i.FirstName);
                    cols.Add("MiddleName")
                       .WithSorting(true)
                        .WithAllowChangeVisibility(true)
                       .WithHeaderText("Middle")
                       .WithValueExpression(i => i.MiddleName);
                    cols.Add("NickName")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("Nick")
                      .WithValueExpression(i => i.NickName);

                    cols.Add("Title")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("Title")
                      .WithValueExpression(i => i.Title);
                    cols.Add("Suffix")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("Suffix")
                      .WithValueExpression(i => i.Suffix);
                    cols.Add("HomePhone")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("HomePhone")
                      .WithValueExpression(i => i.HomePhone);
                    cols.Add("CellPhone")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("CellPhone")
                      .WithValueExpression(i => i.CellPhone);
                    cols.Add("OfficePhone")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("OfficePhone")
                     .WithValueExpression(i => i.OfficePhone);

                    cols.Add("StreetAddress")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("Street")
                      .WithValueExpression(i => i.StreetAddress);
                    cols.Add("City")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("City")
                      .WithValueExpression(i => i.City);
                    cols.Add("State")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("State")
                      .WithValueExpression(i => i.State);
                    cols.Add("Zip")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("Zip")
                      .WithValueExpression(i => i.Zip);

                    cols.Add("Email")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("Email")
                      .WithValueExpression(i => i.Email);
                    cols.Add("Spouse")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("Spouse")
                      .WithValueExpression(i => i.Spouse);
                    cols.Add("Clan")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("Clan")
                      .WithValueExpression(i => i.Clan);
                    cols.Add("Business")
                   .WithSorting(true)
                    .WithAllowChangeVisibility(true)
                   .WithHeaderText("Business")
                   .WithValueExpression(i => i.Business);
                    cols.Add("WaitingStatus")
                    .WithSorting(true)
                     .WithAllowChangeVisibility(true)
                    .WithHeaderText("WaitingStatus")
                    .WithValueExpression(i => i.WaitingStatus);
                    cols.Add("NewMemberOrientation")
                    .WithSorting(true)
                     .WithAllowChangeVisibility(true)
                    .WithHeaderText("NMOrientation")
                    .WithValueExpression(i => i.NewMemberOrientation);
                    cols.Add("Kilted")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("Kilted")
                      .WithValueExpression(i => i.Kilted);

                    cols.Add("ApplicationDate")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("Application")
                     .WithValueExpression(i => i.ApplicationDate.HasValue ? i.ApplicationDate.Value.ToString("MM/dd/yyyy") : "");
                    cols.Add("ElectionDate")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("Election")
                     .WithValueExpression(i => i.ElectionDate.HasValue ? i.ElectionDate.Value.ToString("MM/dd/yyyy") : "");
                    cols.Add("ActivitionDate")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("Activition")
                     .WithValueExpression(i => i.ActivitionDate.HasValue ? i.ActivitionDate.Value.ToString("MM/dd/yyyy") : "");
                    cols.Add("TerminationDate")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("Termination")
                     .WithValueExpression(i => i.TerminationDate.HasValue ? i.TerminationDate.Value.ToString("MM/dd/yyyy") : "");

                    cols.Add("Reason")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("Reason")
                     .WithValueExpression(i => i.Reason);
                    cols.Add("LastUpdate")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("LastUpdate")
                     .WithValueExpression(i => i.LastUpdate.ToString("MM/dd/yyyy"));

                })
                .WithSorting(true, "MemNum")
                .WithPaging(true, 20)
                .WithFiltering(true)
                .WithRetrieveDataMethod((context) =>
                {
                    try
                    {
                        var options = context.QueryOptions;
                        var result = new QueryResult<Member>();
                        string globalSearch = options.GetAdditionalQueryOptionString("search");
                        var status = options.GetFilterString("Status");
                        var statusId = string.IsNullOrEmpty(status) ? -1 : Convert.ToInt32(status);
                        using (var db = new ApplicationDbContext())
                        {
                            var query = db.Members.Where(x => (string.IsNullOrEmpty(globalSearch) ||
                                    (x.FirstName.Contains(globalSearch) ||
                                    x.LastName.Contains(globalSearch) ||
                                    x.Email.Contains(globalSearch) ||
                                    x.Clan.Contains(globalSearch) ||
                                    x.Business.Contains(globalSearch) ||
                                    x.City.Contains(globalSearch))) && (statusId == -1 || x.StatusId == statusId))
                                .Include(x => x.Status)
                                .OrderBy(x => x.MemNum)
                                .AsQueryable();
                            result.TotalRecords = query.Count();
                            if (!String.IsNullOrWhiteSpace(options.SortColumnName))
                            {
                                switch (options.SortColumnName)
                                {
                                    case "Status":
                                        if(options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.StatusId);
                                        else
                                            query = query.OrderByDescending(p => p.StatusId);
                                        break;
                                    case "FirstName":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.FirstName);
                                        else
                                            query = query.OrderByDescending(p => p.FirstName);
                                        break;
                                    case "MiddleName":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.MiddleName);
                                        else
                                            query = query.OrderByDescending(p => p.MiddleName);
                                        break;
                                    case "NickName":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.NickName);
                                        else
                                            query = query.OrderByDescending(p => p.NickName);
                                        break;
                                    case "LastName":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.LastName);
                                        else
                                            query = query.OrderByDescending(p => p.LastName);
                                        break;
                                    case "Title":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.Title);
                                        else
                                            query = query.OrderByDescending(p => p.Title);
                                        break;
                                    case "Suffix":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.Suffix);
                                        else
                                            query = query.OrderByDescending(p => p.Suffix);
                                        break;
                                    case "StreetAddress":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.StreetAddress);
                                        else
                                            query = query.OrderByDescending(p => p.StreetAddress);
                                        break;
                                    case "City":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.City);
                                        else
                                            query = query.OrderByDescending(p => p.City);
                                        break;
                                    case "State":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.State);
                                        else
                                            query = query.OrderByDescending(p => p.State);
                                        break;
                                    case "Zip":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.Zip);
                                        else
                                            query = query.OrderByDescending(p => p.Zip);
                                        break;
                                    case "HomePhone":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.HomePhone);
                                        else
                                            query = query.OrderByDescending(p => p.HomePhone);
                                        break;
                                    case "OfficePhone":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.OfficePhone);
                                        else
                                            query = query.OrderByDescending(p => p.OfficePhone);
                                        break;
                                    case "CellPhone":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.CellPhone);
                                        else
                                            query = query.OrderByDescending(p => p.CellPhone);
                                        break;
                                    case "Email":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.Email);
                                        else
                                            query = query.OrderByDescending(p => p.Email);
                                        break;
                                    case "Clan":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.Clan);
                                        else
                                            query = query.OrderByDescending(p => p.Clan);
                                        break;
                                    case "Kilted":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.Kilted);
                                        else
                                            query = query.OrderByDescending(p => p.Kilted);
                                        break;
                                    case "Business":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.Business);
                                        else
                                            query = query.OrderByDescending(p => p.Business);
                                        break;
                                    case "ApplicationDate":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.ApplicationDate);
                                        else
                                            query = query.OrderByDescending(p => p.ApplicationDate);
                                        break;
                                    case "ElectionDate":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.ElectionDate);
                                        else
                                            query = query.OrderByDescending(p => p.ElectionDate);
                                        break;
                                    case "ActivitionDate":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.ActivitionDate);
                                        else
                                            query = query.OrderByDescending(p => p.ActivitionDate);
                                        break;
                                    case "TerminationDate":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.TerminationDate);
                                        else
                                            query = query.OrderByDescending(p => p.TerminationDate);
                                        break;
                                    case "Reason":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.Reason);
                                        else
                                            query = query.OrderByDescending(p => p.Reason);
                                        break;
                                    case "NewMemberOrientation":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.NewMemberOrientation);
                                        else
                                            query = query.OrderByDescending(p => p.NewMemberOrientation);
                                        break;
                                    case "WaitingStatus":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.WaitingStatus);
                                        else
                                            query = query.OrderByDescending(p => p.WaitingStatus);
                                        break;
                                    case "LastUpdate":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.LastUpdate);
                                        else
                                            query = query.OrderByDescending(p => p.LastUpdate);
                                        break;
                                    case "Spouse":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.Spouse);
                                        else
                                            query = query.OrderByDescending(p => p.Spouse);
                                        break;
                                    case "MemNum":
                                        if (options.SortDirection == SortDirection.Asc)
                                            query = query.OrderBy(p => p.MemNum);
                                        else
                                            query = query.OrderByDescending(p => p.MemNum);
                                        break;
                                }
                            }
                            if (options.GetLimitOffset().HasValue)
                            {
                                query = query.Skip(options.GetLimitOffset().Value).Take(options.GetLimitRowcount().Value);
                            }
                            result.Items = query.ToList();
                        }
                        return result;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }

                })
            );
        }
    }
}