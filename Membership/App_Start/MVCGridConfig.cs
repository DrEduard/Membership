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
                    cols.Add("View").WithHtmlEncoding(false)
                        .WithSorting(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((p, c) => c.UrlHelper.Action("Details", "Members", new { id = p.Id }))
                        .WithValueTemplate("<a href='{Value}' class='btn btn-default' role='button'>View</a>");
                    cols.Add("Edit").WithHtmlEncoding(false)
                        .WithSorting(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((p, c) => c.UrlHelper.Action("Edit", "Members", new { id = p.Id }))
                        .WithVisibility(!isViewer)
                        .WithValueTemplate("<a href='{Value}' class='btn btn-default' role='button'>Edit</a>");
                    cols.Add("Delete").WithHtmlEncoding(false)
                        .WithSorting(false)
                        .WithHeaderText(" ")
                        .WithValueExpression((p, c) => c.UrlHelper.Action("Delete", "Members", new { id = p.Id }))
                        .WithVisibility(!isViewer)
                        .WithValueTemplate("<a href='{Value}' class='btn btn-danger' role='button'>Delete</a>");

                    cols.Add("Id")
                        .WithSorting(true)
                        .WithHeaderText("Id")
                         .WithAllowChangeVisibility(true)
                        .WithValueExpression(i => i.Id.ToString());
                    cols.Add("Status")
                        .WithSorting(true)
                        .WithFiltering(true)
                        .WithHeaderText("Status")
                        .WithAllowChangeVisibility(true)
                        .WithValueExpression(i => i.Status.Name);
                    cols.Add("FirstName")
                       .WithSorting(true)
                       .WithHeaderText("FirstName")
                        .WithAllowChangeVisibility(true)
                       .WithValueExpression(i => i.FirstName);
                    cols.Add("MiddleName")
                       .WithSorting(true)
                        .WithAllowChangeVisibility(true)
                       .WithHeaderText("MiddleName")
                       .WithValueExpression(i => i.MiddleName);
                    cols.Add("NickName")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("NickName")
                      .WithValueExpression(i => i.NickName);
                    cols.Add("LastName")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("LastName")
                      .WithValueExpression(i => i.LastName);
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
                    cols.Add("StreetAddress")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("StreetAddress")
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
                    cols.Add("Kilted")
                      .WithSorting(true)
                       .WithAllowChangeVisibility(true)
                      .WithHeaderText("Kilted")
                      .WithValueExpression(i => i.Kilted);
                    cols.Add("Business")
                    .WithSorting(true)
                     .WithAllowChangeVisibility(true)
                    .WithHeaderText("Business")
                    .WithValueExpression(i => i.Business);
                    cols.Add("OfficePhone")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("OfficePhone")
                     .WithValueExpression(i => i.OfficePhone);
                    cols.Add("ApplicationDate")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("ApplicationDate")
                     .WithValueExpression(i => i.ApplicationDate.HasValue ? i.ApplicationDate.Value.ToString("dd/MM/yyyy") : "");
                    cols.Add("ElectionDate")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("ElectionDate")
                     .WithValueExpression(i => i.ElectionDate.HasValue ? i.ElectionDate.Value.ToString("dd/MM/yyyy") : "");
                    cols.Add("ActivitionDate")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("ActivitionDate")
                     .WithValueExpression(i => i.ActivitionDate.HasValue ? i.ActivitionDate.Value.ToString("dd/MM/yyyy") : "");
                    cols.Add("ResignationDate")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("ResignationDate")
                     .WithValueExpression(i => i.ResignationDate.HasValue ? i.ResignationDate.Value.ToString("dd/MM/yyyy") : "");
                    cols.Add("DeceasedDate")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("DeceasedDate")
                     .WithValueExpression(i => i.DeceasedDate.HasValue ? i.DeceasedDate.Value.ToString("dd/MM/yyyy") : "");
                    cols.Add("NewMemberOrientation")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("NewMemberOrientation")
                     .WithValueExpression(i => i.NewMemberOrientation);
                    cols.Add("WaitingStatus")
                     .WithSorting(true)
                      .WithAllowChangeVisibility(true)
                     .WithHeaderText("WaitingStatus")
                     .WithValueExpression(i => i.WaitingStatus);
                })
                .WithSorting(true, "Id")
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
                                .OrderBy(x => x.Id)
                                .AsQueryable();
                            result.TotalRecords = query.Count();
                            if (!String.IsNullOrWhiteSpace(options.SortColumnName))
                            {
                                switch (options.SortColumnName)
                                {
                                    case "StatusId":
                                        query = query.OrderBy(p => p.StatusId);
                                        break;
                                    case "FirstName":
                                        query = query.OrderBy(p => p.FirstName);
                                        break;
                                    case "MiddleName":
                                        query = query.OrderBy(p => p.MiddleName);
                                        break;
                                    case "NickName":
                                        query = query.OrderBy(p => p.NickName);
                                        break;
                                    case "LastName":
                                        query = query.OrderBy(p => p.LastName);
                                        break;
                                    case "Title":
                                        query = query.OrderBy(p => p.Title);
                                        break;
                                    case "Suffix":
                                        query = query.OrderBy(p => p.Suffix);
                                        break;
                                    case "StreetAddress":
                                        query = query.OrderBy(p => p.StreetAddress);
                                        break;
                                    case "City":
                                        query = query.OrderBy(p => p.City);
                                        break;
                                    case "State":
                                        query = query.OrderBy(p => p.State);
                                        break;
                                    case "Zip":
                                        query = query.OrderBy(p => p.Zip);
                                        break;
                                    case "HomePhone":
                                        query = query.OrderBy(p => p.HomePhone);
                                        break;
                                    case "OfficePhone":
                                        query = query.OrderBy(p => p.OfficePhone);
                                        break;
                                    case "CellPhone":
                                        query = query.OrderBy(p => p.CellPhone);
                                        break;
                                    case "Email":
                                        query = query.OrderBy(p => p.Email);
                                        break;
                                    case "Clan":
                                        query = query.OrderBy(p => p.Clan);
                                        break;
                                    case "Kilted":
                                        query = query.OrderBy(p => p.Kilted);
                                        break;
                                    case "Business":
                                        query = query.OrderBy(p => p.Business);
                                        break;
                                    case "ApplicationDate":
                                        query = query.OrderBy(p => p.ApplicationDate);
                                        break;
                                    case "ElectionDate":
                                        query = query.OrderBy(p => p.ElectionDate);
                                        break;
                                    case "ActivitionDate":
                                        query = query.OrderBy(p => p.ActivitionDate);
                                        break;
                                    case "ResignationDate":
                                        query = query.OrderBy(p => p.ResignationDate);
                                        break;
                                    case "DeceasedDate":
                                        query = query.OrderBy(p => p.DeceasedDate);
                                        break;
                                    case "NewMemberOrientation":
                                        query = query.OrderBy(p => p.NewMemberOrientation);
                                        break;
                                    case "WaitingStatus":
                                        query = query.OrderBy(p => p.WaitingStatus);
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