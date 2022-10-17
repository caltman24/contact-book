import { ContactDataResult, IContactModel } from "../@types/contact";

const apiUrl = import.meta.env.DEV
  ? "https://localhost:7072/api/Contacts"
  : import.meta.env.VITE_BACKEND_URL_PROD;

export const fetchContacts = async () => {
  const res = await fetch(apiUrl);
  return res.json() as Promise<ContactDataResult>;
};

export const addContactToDB = async (contact: IContactModel) => {
  const res = await fetch(apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(contact),
  });
  return await res.json();
};
