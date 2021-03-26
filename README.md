# MVOHWR Policy Difference Engine

## Project Background 

### EN 
Canada School of Public Service’s Public Sector Innovation team is working with a multidisciplinary team from across the Government of Canada (ESDC, Labour Program, CFR, and DoJ) to conduct a Rules as Code experiment to transform the Motor Vehicle Operator Hours of Work Regulations into a publicly accessible API. 

Technically executed by ESDC developers, this project will apply the Rules as Code process to the Motor Vehicle Operator Hours of Work Regulations. The group has worked collaboratively in a three-week sprint to conceptually model each section of the existing regulation and create logic flows outlining the application of the regulation in a widely accessible format. The coded regulation was done in a globally compatible OpenFisca format and will be published here as an API for all to access and connect to as a single source of interpretation of these regulations. 
We've released all the code here, for anyone to use. This code is not the authoritative source of this regulation, the regulation in its entirety can be found here: Motor Vehicle Operators Hours of Work Regulations (justice.gc.ca) 

### FR 
L'équipe d'innovation dans le secteur public de l'École de la fonction publique du Canada collabore avec une équipe multidisciplinaire du gouvernement du Canada (ESDC, Programme du travail, CFR et DoJ) pour mener une expérience de Rules as Code afin de transformer le Règlement sur les heures de travail des conducteurs de véhicules automobiles en une API accessible au public.  

Techniquement exécuté par les développeurs du CESD, ce projet appliquera le processus Rules as Code au Règlement sur les heures de travail des conducteurs de véhicules automobiles. Le groupe a travaillé en collaboration dans un sprint de trois semaines pour modéliser conceptuellement chaque section du règlement existant et créer des flux logiques décrivant l'application du règlement dans un format largement accessible. La réglementation codée a été réalisée dans un format OpenFisca compatible avec le monde entier et sera publiée ici sous la forme d'une API à laquelle tous pourront accéder et se connecter en tant que source unique d'interprétation de cette réglementation.  
Nous avons publié tout le code ici, pour que chacun puisse l'utiliser. Ce code n'est pas la source faisant autorité de ce règlement, le règlement dans son intégralité peut être trouvé ici : Règlement sur les heures de travail des conducteurs de véhicules automobiles (justice.gc.ca)


## Description

The MVOHWR policy difference engine is a web application that is able to measure proposed policy changes to the Motor Vehicle Operator Hours of Work Regulations. The regulations specify how much overtime is allotted to different types of motor vehicle operators based on their work schedule. A separate project has been implemented that encodes these rules into an open API. This web application make use of that API. 

The user is able to enter in a weekly hours for a motor vehicle operator in the various categories outlined in the regulations. These categories include City Motor Vehicle Operator (CMVO), Highway Motor Vehicle Operator (HMVO), and Other. "Other" hours worked are hours that do not fall into either the CMVO or HMVO categories, and are thus regulated by the Canada Labour Code, some parts of which have been encoded into this system. It can also include hours worked as a Bus operator, which is a category defined in the MVOHWR, but hours worked as a bus operator for overtime calculation purposes are NOT defined in the MVOHWR, and so values from the Canada Labour Code is used. 

It is assumed that any hours entered in the schedule are non-holiday hours, since holiday hours are not accounted for by the MVOHWR. The user can specify that a day of the week is a holiday, in which case it will automatically set the hours for all 3 categories in that day to 0.

Once the schedule has been entered, the user can also specify proposed changes to the regulations. These changes can take the form of manipulating different numbers associated with the regulations. For example, the curent standard daily hours for a CMVO are 9 and the standard weekly hours for a CMVO are 45. Suppose you want to see how much overtime a given schedule would be entitled to if the regulation changed those values to be in line with the Canada Labour Code. So the user would set the "Standard CMVO Daily Hours"  in the "Proposed Change" column to 8 and the "Standard CMVO Weekly Hours" in the "Proposed Change" column to 40. The user can then run the simulation to see the overtime for the schedule in the current scenario and the proposed scenario. This can help inform decisions around changes to the regulation.


## Future Feature Possibilities

### Product Features
- Integration with real (or mocked) data to run multiple scenarios and aggregate results
- Show breakdown of how the overtime result for a scenario was calculated

### Engineering Features
- Code coverage
- Persistent storage so that test scenarios can be saved
- Data integration
- Front-end tests
