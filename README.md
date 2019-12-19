# MigrationApi

The Migration Api serves as a backend service for the migrations portal.

This is intended to provide a single interface for managing practice-migration related processes. 

- To provide integrations needed to carry out these processes. eg: PDS (currently mocked), prm-deductions components etc. 
- Orchestrate all processes

Contracts

->
GET /patientinfo/nhsNumber
<-
{
    "patientName": "Rachel Roth",
    "practice": "GP Practice 2",
    "telephone": "07700 900457",
    "email": "rachel.roth@example.com",
    "dob": "1978-01-05T00:00:00",
    "nhsNumber": "2234567890"
}

->
GET /patients
<-



 - Used to retrieve details of a patient from NHS number
 




