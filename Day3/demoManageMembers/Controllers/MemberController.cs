using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using demoManageMembers.Models;
using Microsoft.AspNetCore.Authorization;

namespace demoManageMembers.Controllers
{
    public class MembersController : Controller
    {
        private  IMemberHandler resp = new MemberHandler();

        public IActionResult Search(string SearchString)
        {
            if (String.IsNullOrEmpty(SearchString))
            {
                return RedirectToAction("List");
            }
            return View("List",resp.GetMembersByName(SearchString));
        }

        [Authorize("Admin")]
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
         public IActionResult CreateMember(Member member){

            if (member==null)
            {
                 return RedirectToAction("List");
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            resp.AddMember(member);
            return RedirectToAction("List");
        }
        public IActionResult Details(int? i){
            if (!i.HasValue)
            {
                return RedirectToAction("List");
            }
            Member member = resp.GetMemberByIndex(i.Value);
            if (member==null)
            {
                   return RedirectToAction("List");
            }
             return View(member);
        }
        public IActionResult List()
        {
            return View(resp.GetMembers());
        }
        [Authorize("Admin")]
        public IActionResult Delete(int? i)
        {
            if (!i.HasValue)
            {
              return RedirectToAction("List");
            }
            Member member = resp.GetMemberByIndex(i.Value);
            if (member==null)
            {
                   return RedirectToAction("List");
            }
            ViewBag.IndexDelete=i.Value;
             return View(member);  
        }
        [HttpPost]
        public IActionResult DeleteMember(int? i)
        {
            if (!i.HasValue)
            {
              return RedirectToAction("List");
            }
            resp.DeleteMember(i.Value);
            
            return RedirectToAction("List");
        }
        [Authorize("Admin")]
        public IActionResult EditForm(int? i)
        {
             if (!i.HasValue)
            {
                return RedirectToAction("List");
            }
            Member member = resp.GetMemberByIndex(i.Value);
            if (member==null)
            {
                   return RedirectToAction("List");
            }
            ViewBag.Index = i;
            return View(member);
        }
        [HttpPost]
        public IActionResult Edit(int index,Member member)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("EditForm",new{i=index});
            }
            if (index == null || member == null)
            {
                return RedirectToAction("List"); 
            }
            Member memberUpdate = resp.UpdateMember(index, member);
            return RedirectToAction("Details",memberUpdate);
        }
    }
}

