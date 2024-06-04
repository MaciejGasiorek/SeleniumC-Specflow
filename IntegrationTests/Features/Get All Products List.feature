Feature: Get All Products List

A short summary of the feature

@tag1
Scenario: Get All Products List
	When I send a Get request to get product lists
	Then I should get list of products and response should contains 'Blue Top'
