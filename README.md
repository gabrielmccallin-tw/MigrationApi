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

# Lifecyle and deployment

GoCD executes a [pipeline](https://prod.gocd.patient-deductions.nhs.uk/go/tab/pipeline/history/prm-migration-poc) which builds, tests and deploys the application to ECS.

Definition of the pipeline is in `gocd/pipeline.yaml`.

It is possible to reproduce all steps that execute on the CI agents using docker and [Dojo](https://github.com/kudulab/dojo).

To install Dojo on Mac:
```
brew install kudulab/homebrew-dojo-osx/dojo
```

## Tasks

To build the project and create artifacts in `out` directory:
```
./tasks build
```

To run the unit tests:
```
./tasks test
```

To build the docker image locally:
```
./tasks build_docker_local
```

To test the docker image locally:
```
./tasks test_docker_local
```

## Deployment tasks

You need to authenticate with AWS and export your credentials on the terminal. You can do so with:
```
dojo -c Dojofile-infra
# Then type-in your details:
aws-cli-assumerole -rmfa <role-arn> <your-username> <mfa-otp-code>
```
The output with AWS credentials will follow. Type `exit` and copy paste the export commands on the terminal.

To run terraform plan:
```
./tasks tf_plan create
```

Then review the plan and apply:
```
./tasks tf_apply
```
