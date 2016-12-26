Feature: FeatureStart
	I can only start training if there are some planned exercise
	I cant start training if plan is empty


Scenario: Try start training with filled plan
	Given My training is stopped and plan is empty
	And I have added Squats to training plan
	And I have added Crunches to training plan
	When I press start
	Then Training starts setting now as start time

Scenario: Try start training with empty plan
	Given My training is stopped and plan is empty
	When I press start
	Then Training is not started

Scenario: Finish Training
	Given My training had started
	When I press finish
	Then Training is not started
	And I have my training saved