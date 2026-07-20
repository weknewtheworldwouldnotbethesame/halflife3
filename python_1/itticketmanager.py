#Support ticket system
#Title: Help I can't get up. I lost connection

import csv
import os
from datetime import datetime

#FILES CONFIGURATION

USER_FILE = "users.csv"
TICKETS_FILE = "tickets.csv"

USER_FIELDS = ["username", "password", "user_type"]
TICKETS_FIELDS = ["ticket_id", "client_name", "title", "description", "status", "assigned_to", "created_date", "notes"]

#FUNCTIONS


def load_users():
    if not os.path.exists(USER_FILE):
        return []  
    with open (USER_FILE, newline="") as f:
        return list (csv.DictReader(f))

def load_tickets():
    if not os.path.exists(TICKETS_FILE):
        return []
    with open (TICKETS_FILE, newline="") as f:
        return list (csv.DictReader (f))
    

def save_users(users):
    with open( USER_FILE, "w", newline="") as f:
        writer = csv.DictWriter(f, fieldnames=USER_FIELDS)
        writer.writeheader()
        writer.writerows(users)

def save_tickets(tickets):
    with open(TICKETS_FILE, "w", newline="") as f:
        writer = csv.DictWriter(f, fieldnames=TICKETS_FIELDS)
        writer.writeheader()
        writer.writerows(tickets)

#================================================================

#INTIALIZATION OF THE PROGRAM:

#================================================================


def initialize_system():
    users = load_users()
    if len(users) == 0:
        #print ("\n" + "=" * 60)
        print ("CREATING SAMPLE USERS FOR FIRST RUN")
        print ("=" * 60)  

        sample_users = [
            {"username": "client1", "password": "client123", "user_type": "client"},
            {"username": "client2", "password": "client123", "user_type": "client"},
            {"username": "worker1", "password": "worker123", "user_type": "worker"},
            {"username": "worker2", "password": "worker123", "user_type": "worker"},
            {"username": "manager1", "password": "manager123", "user_type": "manager"},
        ]
        
        #save_users(sample_users)
        #print("\n✅✅✅ Sample user created" )
        #print( "\nLOGIN CREDENTIALS:")
        #print(" CLIENT → username: client1      password: client123")
        #print("  CLIENT  → username: client2    password: client123")  
        #print("  WORKER  → username: worker1    password: worker123")
        #print("  WORKER  → username: worker2    password: worker123")  
        #print("  MANAGER → username: manager1   password: manager123")
        #print("="*60 + "\n")


#======================================
#AUTHENTICATION 
#======================================

def authenticate_user():
    username = input("Enter username: ")  
    password = input("Enter password: ")  

    users = load_users()

    for user in users:
        if user["username"] == username and user["password"] == password: 
            return user
        
    return None

def login():
    while True:

        user = authenticate_user()

        if user is not None:
            print(f"\n✅✅✅ Welcome, {user['username']}!")
            print(f" Role: {user['user_type'].upper()}")
            return user
        
        else:
            print("\n❌❌❌ Invalid credentials. Please try again\n")  
# ============================================================
# UTILITY FUNCTIONS
# ============================================================

def get_next_ticket_id():  
    """Get the next ticket ID number"""
    tickets = load_tickets()
    if len(tickets) == 0:
        return "1"
    return str(int(tickets[-1]["ticket_id"]) + 1)

def display_ticket(ticket):
    print(f"\n  ID: {ticket['ticket_id']} | Status: {ticket['status']}")
    print(f"    Title: {ticket['title']}")
    print(f"    Created by: {ticket['client_name']} ({ticket['created_date']})")
    print(f"    Description: {ticket['description']}")
    print(f"    Assigned to: {ticket['assigned_to']}") 

    if ticket['notes']:
        print(f"    Notes: {ticket['notes']}")

# ============================================================
# CLIENT FUNCTIONS
# ============================================================


def client_create_ticket(client_name):
    print("\n" + "="*60)
    print("CREATE NEW TICKET")
    print("="*60)
    
    title = input("Ticket title: ")
    description = input("Ticket description: ")

    ticket_id = get_next_ticket_id()
    ticket = {
        "ticket_id": ticket_id,
        "client_name": client_name,
        "title": title,
        "description": description,
        "status": "New",
        "assigned_to": "Unassigned",
        "created_date": datetime.now().strftime("%Y-%m-%d %H:%M"),
        "notes": ""
    }

    tickets = load_tickets()
    tickets.append(ticket)
    save_tickets(tickets)
    
    print(f"\n✅✅✅ Ticket created successfully")
    print(f"    Ticket ID: {ticket_id}")

def client_view_tickets(client_name):
    print("\n" + "=" * 60)
    print("YOUR TICKETS")
    print("=" * 60)

    tickets = load_tickets()
    my_tickets = [t for t in tickets if t["client_name"] == client_name]

    if not my_tickets: 
        print("\n No Ticket found.")
        return
    
    for ticket in my_tickets:
        display_ticket(ticket)
    
def client_menu(current_user):
    while True:
        print("\n" + "=" * 60)
        print(f" CLIENT MENU - {current_user['username']}")
        print("=" * 60)
        print("1. Create new ticket")
        print("2. View your tickets")
        print("3. Logout")

        choice = input("\nSelect option (1-3): ")  
        if choice == "1":
            client_create_ticket(current_user["username"])
        elif choice == "2":
            client_view_tickets(current_user["username"]) 
            print("\n 👋 Logging out...")
            break
        else:
            print("\n❌❌❌ invalid choice. Please try again")


# ============================================================
# WORKER FUNCTIONS
# ============================================================

def worker_view_tickets():
    print("\n" + "=" * 60)  
    print(" ALL TICKETS")
    print("=" * 60)

    tickets = load_tickets()

    if not tickets:
        print("\n No tickets found")
        return None
    
    unresolved = [t for t in tickets if t["status"] != "Closed"]

    if not unresolved:
        print("\n All tickets are closed!")
        return None
    
    for ticket in unresolved:
        display_ticket(ticket)
    
    return unresolved

def worker_select_ticket():
    tickets = worker_view_tickets()

    if not tickets:
        return None
    
    ticket_id = input("\nEnter ticket ID to select: ")

    for ticket in tickets:
        if ticket["ticket_id"] == ticket_id:
            return ticket
    
    print("\n❌❌❌ Ticket not found")
    return None

def worker_work_on_ticket(ticket):
    print("\n" + "=" * 60)
    print(f" WORKING ON TICKET #{ticket['ticket_id']}")
    print("=" * 60)

    display_ticket(ticket)

    print("\n1. Add notes")
    print("2. Attempt solution")
    print("3. Back to Menu")

    choice = input("\nSelect option (1-3): ")

    if choice == "1":
        note = input("Add note: ")
        ticket["notes"] = (ticket["notes"] + " | " + note) if ticket["notes"] else note
        ticket["status"] = "In Progress"

        tickets = load_tickets()
        for i, t in enumerate(tickets):
            if t["ticket_id"] == ticket["ticket_id"]:
                tickets[i] = ticket
        save_tickets(tickets)
        print("\n✅ Note added.")
    
    elif choice == "2":
        print("\nDid you solve the problem?")
        print("1. Yes, problem solved")
        print("2. No, escalate to manager")
        
        sub_choice = input("\nSelect (1-2): ")
        
        if sub_choice == "1":
            ticket["status"] = "Closed"
            ticket["notes"] = (ticket["notes"] + " | RESOLVED") if ticket["notes"] else "RESOLVED"
            print("\n✅ Ticket marked as closed.")
        elif sub_choice == "2":
            ticket["status"] = "Escalated to Manager"
            print("\n⬆️ Ticket escalated to manager.")
        
        tickets = load_tickets()
        for i, t in enumerate(tickets):
            if t["ticket_id"] == ticket["ticket_id"]:
                tickets[i] = ticket
        save_tickets(tickets)
 
def worker_menu(current_user):
    while True:
        print("\n" + "="*60)
        print(f"WORKER MENU - {current_user['username']}")
        print("="*60)
        print("1. View all tickets")
        print("2. Work on a ticket")
        print("3. Logout")
        
        choice = input("\nSelect option (1-3): ")
        
        if choice == "1":
            worker_view_tickets()
        elif choice == "2":
            ticket = worker_select_ticket()
            if ticket:
                worker_work_on_ticket(ticket)
        elif choice == "3":
            print("\n👋 Logging out...")
            break
        else:
            print("\n❌ Invalid choice. Please try again.")
 
# ============================================================
# MANAGER FUNCTIONS
# ============================================================
 
def manager_view_all_tickets():
    print("\n" + "="*60)
    print("ALL TICKETS (MANAGER VIEW)")
    print("="*60)
    
    tickets = load_tickets()
    
    if not tickets:
        print("\n   No tickets found.")
        return None
    
    for ticket in tickets:
        display_ticket(ticket)
    
    return tickets
 
def manager_view_escalated():
    print("\n" + "="*60)
    print("ESCALATED TICKETS")
    print("="*60)
    
    tickets = load_tickets()
    escalated = [t for t in tickets if t["status"] == "Escalated to Manager"]
    
    if not escalated:
        print("\n   No escalated tickets.")
        return None
    
    for ticket in escalated:
        display_ticket(ticket)
    
    return escalated
 
def manager_handle_ticket(ticket):
    print("\n" + "="*60)
    print(f"MANAGING TICKET #{ticket['ticket_id']}")
    print("="*60)
    
    display_ticket(ticket)
    
    print("\n1. Add notes/final decision")
    print("2. Resolve ticket")
    print("3. Back to menu")
    
    choice = input("\nSelect option (1-3): ")
    
    if choice == "1":
        note = input("Add note: ")
        ticket["notes"] = (ticket["notes"] + " | " + note) if ticket["notes"] else note
        
        tickets = load_tickets()
        for i, t in enumerate(tickets):
            if t["ticket_id"] == ticket["ticket_id"]:
                tickets[i] = ticket
        save_tickets(tickets)
        print("\n✅ Note added.")
    
    elif choice == "2":
        ticket["status"] = "Closed"
        ticket["notes"] = (ticket["notes"] + " | MANAGER RESOLVED") if ticket["notes"] else "MANAGER RESOLVED"
        
        tickets = load_tickets()
        for i, t in enumerate(tickets):
            if t["ticket_id"] == ticket["ticket_id"]:
                tickets[i] = ticket
        save_tickets(tickets)
        print("\n✅ Ticket resolved and closed.")
 
def manager_select_ticket(escalated_only=False):
    if escalated_only:
        tickets = manager_view_escalated()
    else:
        tickets = manager_view_all_tickets()
    
    if not tickets:
        return None
    
    ticket_id = input("\nEnter ticket ID: ")
    
    for ticket in tickets:
        if ticket["ticket_id"] == ticket_id:
            return ticket
    
    print("\n❌ Ticket not found.")
    return None
 
def manager_menu(current_user):
    while True:
        print("\n" + "="*60)
        print(f"MANAGER MENU - {current_user['username']}")
        print("="*60)
        print("1. View all tickets")
        print("2. Review escalated tickets")
        print("3. Handle a ticket")
        print("4. Logout")
        
        choice = input("\nSelect option (1-4): ")
        
        if choice == "1":
            manager_view_all_tickets()
        elif choice == "2":
            manager_view_escalated()
        elif choice == "3":
            ticket = manager_select_ticket()
            if ticket:
                manager_handle_ticket(ticket)
        elif choice == "4":
            print("\n👋 Logging out...")
            break
        else:
            print("\n❌ Invalid choice. Please try again.")
 
# ============================================================
# MAIN PROGRAM
# ============================================================
 
def main():
    print("\n" + "="*60)
    print("SUPPORT TICKET MANAGER SYSTEM")
    print("="*60)
    
    initialize_system()
    
    # Keep running until user exits
    while True:
        print("\n" + "="*60)
        print("LOGIN REQUIRED")
        print("="*60)
        
        current_user = login()
        
        user_type = current_user["user_type"]
        
        if user_type == "client":
            client_menu(current_user)
        elif user_type == "worker":
            worker_menu(current_user)
        elif user_type == "manager":
            manager_menu(current_user)
        
        # Ask if they want to login again
        print("\n" + "="*60)
        again = input("Do you want to login as another user? (yes/no): ").lower()
        
        if again == "yes" or again == "y":
            continue  # Go back to login
        else:
            break  # Exit the program
    
    print("\n" + "="*60)
    print("Thank you for using Support Ticket Manager!")
    print("="*60 + "\n")
 
if __name__ == "__main__":
    main()