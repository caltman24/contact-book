import { useMutation } from "@tanstack/react-query";
import { FormEvent, useState } from "react";
import { IContactModel } from "../@types/contact";
import { addContactToDB } from "../api/dataAccess";

const AddContactForm = () => {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [phone, setPhone] = useState("");

  const newContactMutation = useMutation((newContact: IContactModel) => {
    return addContactToDB(newContact);
  });

  const resetForm = () => {
    setFirstName("");
    setLastName("");
    setEmail("");
    setPhone("");
  };

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault();

    const newContact = {
      firstName,
      lastName,
      emailAddresses: [
        {
          emailAddress: email,
        },
      ],
      phoneNumbers: [
        {
          phoneNumber: phone,
        },
      ],
    } as IContactModel;

    newContactMutation.mutate(newContact);
    resetForm();
  };

  return (
    <form className="add-contact" onSubmit={handleSubmit}>
      <div className="name">
        <span>
          <label htmlFor="firstName">First Name:</label>
          <input
            type="text"
            name="firstName"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
            required
          />
        </span>

        <span>
          <label htmlFor="lastName">Last Name:</label>
          <input
            type="text"
            name="lastName"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
            required
          />
        </span>
      </div>

      <div>
        <label htmlFor="email">Email Address:</label>
        <input
          type="email"
          name="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
      </div>

      <div>
        <label htmlFor="phone">Phone Number:</label>
        <input
          type="tel"
          name="phone"
          value={phone}
          onChange={(e) => setPhone(e.target.value)}
          maxLength={10}
          required
        />
      </div>

      <button type="submit" className="btn sm">
        Add Contact
      </button>
    </form>
  );
};

export default AddContactForm;
