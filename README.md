# Hotel Room Reservation Desktop Application

This application was built for the ASI Karikas 2023 competition. One of the goals of the competition was to build a hotel room reservation application.
https://asikarikas.ee/


# Information
* Built using .NET Maui
* Supports only Windows (theoretically Mac as well but I haven't tested)
* Uses SQLite and writes to a .DB file

# Main Features
* The customer can view available rooms and the information associated with them.
* The customer can book a room from a specific date to another specific date.
* The reserved room cannot be rebooked during the reserved period.
* The rooms are categorized as types, and each type has its own amount of beds. All rooms have a price per night cost.
* The customer can view the full price of their reservation, which is based on the price per night but with a 1.5 multiplier on weekends (Saturday-Sunday night and Sunday-Monday night).

# Additonal Features
* The customer can view the hotel's contact information and location.
* The customer can search for rooms based on category, price, and dates.
* The customer must enter their personal data to make a reservation.
* The hotel employee/admin can view customer data related to the reservation, room data, and reservation time period.
* The hotel employee/admin can add and delete rooms.

# Usage
* Download git for your computer
* Download Visual Studio 2022
	* Download .NET Maui using Visual Studio Installer
	* Make sure that you have .NET 6.0 installed!

* Clone the repository by opening a command prompt in some random folder and typing:
 `git clone https://github.com/LauriSarap/Hotell567.git`
* Open the solution in Visual Studio
* Run the application through Visual Studio

# Images
<picture>
  <source media=srcset="https://user-images.githubusercontent.com/93860007/220036530-5a36310d-3a03-4497-bfb2-91deadcc04c4.PNG">
  <img width="700" height="340" alt="Login Page" src="https://user-images.githubusercontent.com/93860007/220036530-5a36310d-3a03-4497-bfb2-91deadcc04c4.PNG">
</picture>

<picture>
  <source media=srcset="https://user-images.githubusercontent.com/93860007/220038253-6650a012-b7e6-4a59-9cba-11ec98229623.PNG">
  <img width="700" height="350" alt="Rooms page" src="https://user-images.githubusercontent.com/93860007/220038253-6650a012-b7e6-4a59-9cba-11ec98229623.PNG">
</picture>

<picture>
  <source media=srcset="https://user-images.githubusercontent.com/93860007/220038186-ab173853-24bc-426a-8f42-1cf6ff259ea6.PNG">
  <img width="700" height="350" alt="Rooms page" src="https://user-images.githubusercontent.com/93860007/220038186-ab173853-24bc-426a-8f42-1cf6ff259ea6.PNG">
</picture>
<picture>
  <source media=srcset="https://user-images.githubusercontent.com/93860007/220038273-553c6866-77c8-4637-96cf-0a8fb3030559.PNG">
  <img width="430" height="200" alt="Account info" src="https://user-images.githubusercontent.com/93860007/220038273-553c6866-77c8-4637-96cf-0a8fb3030559.PNG">
</picture>
