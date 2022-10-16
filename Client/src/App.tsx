import { useQuery } from "@tanstack/react-query";
import { useState } from "react";
import { fetchContacts } from "./api/dataAccess";
import "./App.css";
import AddContactForm from "./components/AddContactForm";
import ContactCard from "./components/ContactCard";

function App() {
  const [menuOpen, setMenuOpen] = useState(false);
  const contacts = useQuery(["contacts"], fetchContacts);

  if (contacts.isLoading) {
    return (
      <div className="App">
        <h1>Loading...</h1>
      </div>
    );
  }

  if (contacts.isError) {
    return (
      <div className="App">
        <h1>Error loading contacts</h1>
      </div>
    );
  }

  return (
    <div className="App">
      <h1>Contacts</h1>

      <button
        className={`btn ${menuOpen ? "close" : ""}`}
        onClick={() => setMenuOpen((prev) => !prev)}
      >
        {menuOpen ? "Close" : "Add Contact"}
      </button>

      {menuOpen && <AddContactForm />}

      <ul className="contact_list">
        {contacts.data?.map((contact) => (
          <li key={contact.id}>
            <ContactCard contact={contact} />
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;
