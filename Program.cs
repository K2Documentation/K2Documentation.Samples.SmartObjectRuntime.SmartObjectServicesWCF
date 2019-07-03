using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//we added a service reference to http://k2.denallix.com:8888/SmartObjectServices/wcf/Workflow%20Reports/Workflow%20General
using K2Documentation.Samples.SmartObjectRuntime.SmartObjectServicesWCF.WorkflowGeneralReport_WCFService;

//to create filters for the _Filtered methods, you need to import the SourceCode.SMartObject.Client namespace
//(you can also construct the filter XML manually without this reference)
using SourceCode.SmartObjects.Client.Filters;
using SourceCode.SmartObjects.Client;
using System.Xml;

namespace K2Documentation.Samples.SmartObjectRuntime.SmartObjectServicesWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            //demo the simple list method
            ExecuteListMethodWCF();
            //demo the filtered list method
            ExecuteFilteredListMethodWCF();
        }

        //sample: simple list method for the Workflow General/Process Instance SmartObject
        static void ExecuteListMethodWCF()
        {
            Console.WriteLine("Executing simple List method via WCF");
            //set up the service client
            WorkflowGeneralReport_WCFService.Process_InstanceSvcClient processInstanceSvcClient = new Process_InstanceSvcClient();
            //set credentials
            processInstanceSvcClient.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            //call the appropriate method. Note that we are passing a data contract into the method specifying the object we want returned
            WorkflowGeneralReport_WCFService.Process_Instance[] processInstanceList = processInstanceSvcClient.Process_InstanceSvc_List(new Process_Instance());
            foreach (Process_Instance processInstance in processInstanceList)
            {
                Console.WriteLine("Folio: " + processInstance.Folio + " | ProcInstID: " + processInstance.ProcessInstanceID.ToString() + " | Status: " + processInstance.Status);
            }
            Console.WriteLine("Completed execution of simple List method via WCF");
            Console.ReadLine();
        }

        //sample: filtered list method for the Workflow General/Process Instance SmartObject
        static void ExecuteFilteredListMethodWCF()
        {
            Console.WriteLine("Executing filtered List method via WCF (Active instances only)");
            //set up the service client
            WorkflowGeneralReport_WCFService.Process_InstanceSvcClient processInstanceSvcClient = new Process_InstanceSvcClient();
            processInstanceSvcClient.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            //set up a filter object (you could also constrcut the filter directly in XML if you prefer) 
            Equals statusEquals = new Equals();
            PropertyExpression statusPropertyExp = new PropertyExpression("Status", PropertyType.Text);
            ValueExpression statusValueExp = new ValueExpression("Active", PropertyType.Text);
            statusEquals.Left = statusPropertyExp;
            statusEquals.Right = statusValueExp;

            // Serialize the filter to XML
            FilterExp filterExpression = new FilterExp(statusEquals);
            XmlDocument filterXml = filterExpression.GetFilterXml();
            string filterXmlString = filterXml.InnerXml;

            //call the filter method, passing in the filter XML
            WorkflowGeneralReport_WCFService.Process_Instance[] processInstanceList = processInstanceSvcClient.Process_InstanceSvc_List_Filtered(filterXmlString);
            foreach (Process_Instance processInstance in processInstanceList)
            {
                Console.WriteLine("Folio: " + processInstance.Folio + " | ProcInstID: " + processInstance.ProcessInstanceID.ToString());
            }
            Console.WriteLine("Completed execution of filtered List method via WCF (Active instances only)");
            Console.ReadLine();
        }        
    }
}
