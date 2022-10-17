import { IContactModel } from "../@types/contact";

interface IContactCardProps {
  contact: IContactModel;
}

const ContactCard = ({ contact }: IContactCardProps) => {
  return (
    <div className="contact_card">
      <div className="contact-name">
        {contact.firstName} {contact.lastName}
      </div>

      <div>
        <p>Email Addresses:</p>
        <ul className="contact-emails">
          {contact.emailAddresses.map((c, i) => (
            <li key={`${i}+${c.emailAddress}`}>{c.emailAddress}</li>
          ))}
        </ul>
      </div>

      <div>
        <p>Phone Numbers:</p>
        <ul className="contact-phones">
          {contact.phoneNumbers.map((c, i) => (
            <li key={`${i}+${c.phoneNumber}`}>{c.phoneNumber}</li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default ContactCard;
