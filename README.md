# prm-migration-poc

This service manages a list of patients seen during a practice migration.

Features:
- PDS mock for getting patient information based on a NHS Number
- view list of patients
- add patient to the list
- delete all patients in the list
- transfer all patient records to new clinical system (not implemented)

The database is mocked within the application; restarts of the application will wipe any data stored.

The application is exposed on port 80.


---
## Contract

### **patientinfo**
Find patient in PDS and return some of their information.

- **GET `/patientinfo/{nhsNumber}`**
    - Returns patient information from PDS (mocked)

- **Parameters**  
    - `nhsNumber: string`
        - required

- **Success response**
    - Code: **200**
    - Content
        ```
        {
            "patientName": "string",
            "practice": "string",
            "telephone": "string",
            "email": "string",
            "dob": "string",
            "nhsNumber": "string"
        }
        ```

- **Error response**
    - Code: **500** (patient does not exist)
    - Code: **404** (empty nhsNumber) 


- **Example**
    ```
    curl --request GET \
    --url http://localhost:5000/patientinfo/2234567890
    ```
---
### **patients**
Manage a list of patients that are pending migration.

**POST `/patients`**

- **Description**
    - Add patient to list

- **Data parameters**
    - Payload (example)
    ```
    {
        "ods": "Practice X",
        "patientName": "Patient X",
        "nhsNumber": "1234567890",
        "requester": "Mr Requestor X"
    }
    ```

- **Success response**
    - Code: **200**  
    Content:
    ```
    {
        "PatientName": "Patient X",
        "Requester": "Mr Requestor X",
        "Status": "Pending",
        "RequestDate": "2019-12-19T14:22:01.851427+00:00",
        "NhsNumber": "1234567890"
    }
    ```
    - Code: **200**  
    Content:
    ```
    Patient already queued for transfer
    ```


- **Error response**
    - Code: **500** (no nhsNumber field)

- **Example**
    ```
    curl --request POST \
    --url http://localhost:5000/patients \
    --header 'content-type: application/json' \
    --data '{
            "ods": "Practice X",
            "patientName": "Patient X",
            "nhsNumber": "2234567890",
            "requester": "Mr Requestor X"
        }
    '
    ```

---
**GET `/patients`**

- **Description**
    - Get list of patients

- **Success response**
    - Code: **200**  
    Content
    ```
    [{
        "patientName": "Patient Three",
        "requester": "Mr Requestor One",
        "status": "Pending",
        "requestDate": "2019-12-19T14:21:45.60063",
        "nhsNumber": "333333333"
    }, {
        "patientName": "Patient X",
        "requester": "Mr Requestor X",
        "status": "Pending",
        "requestDate": "2019-12-19T14:22:01.851427",
        "nhsNumber": "1234567890"
    }]
    ```
- **Example**
    ```
    curl --request GET \
    --url http://localhost:5000/patients
    ```

---
**DELETE `/patients`**

- **Description**
    - Delete all patients from the list

- **Success response**
    - Code: **200**  
    Content
    ```
    patients cleared
    ```
    
- **Example**
    ```
    curl --request DELETE \
    --url http://localhost:5000/patients
    ```
---

**POST `/transferall`**

- **Description**
    - Migrate all patients to target clinical system

- **Success response**
    - Code: **200**  
    Content
    ```
    ```
    
- **Example**
    ```
    curl --request POST \
    --url http://localhost:5000/transferall
    ```
 




