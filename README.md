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

POST /patients

{
	
    "ods": "Practice X",

    "patientName": "Patient X",

    "nhsNumber": "1234567890",

    "requester": "Mr Requestor X"

}

<-

{

    "PatientName": "Patient X",

    "Requester": "Mr Requestor X",

    "Status": "Pending",

    "RequestDate": "2019-12-19T14:22:01.851427+00:00",

    "NhsNumber": "1234567890"

}

->

GET /patients

<-

[

    {

        "patientName": "Patient Three",

        "requester": "Mr Requestor One",

        "status": "Pending",

        "requestDate": "2019-12-19T14:21:45.60063",

        "nhsNumber": "333333333"

    },

    {

        "patientName": "Patient X",

        "requester": "Mr Requestor X",

        "status": "Pending",

        "requestDate": "2019-12-19T14:22:01.851427",

        "nhsNumber": "1234567890"

    }

]

->

DELETE / patients

<-

"confirmation string output"

->

POST /transferall

<-

"confirmation string output"

 




