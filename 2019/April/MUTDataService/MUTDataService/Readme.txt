1. Get all MUTJobs: GET http://localhost:58961/odata/MUTJob/
2. Get a MUTJob by ID: GET http://localhost:58961/odata/MUTJob/{Id}
3. Add a MUTJob : POST http://localhost:58961/odata/MUTJob/
		Body: Content-Type: application/json		{
				 "CreateDateTime": "2019-11-08T14:41:53.966108-05:00",
				 "AccountId": 99
		}4. PUT http://localhost:58961/odata/MUTJob/{Id} 		Body: Content-Type: application/json		{
				"Id": {Id}
				"CreateDateTime": "2019-11-08T14:41:53.966108-05:00",
				"AccountId": 99
		}
5. Delete a MUTJob: DELETE http://localhost:58961/odata/MUTJob/{Id} 
