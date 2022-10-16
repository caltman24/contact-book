export interface IEmailAddressModel {
  emailAddress: string;
}

export interface IPhoneNumberModel {
  phoneNumber: string;
}

export interface IContactModel {
  id: string | number;
  firstName: string;
  lastName: string;
  emailAddresses: IEmailAddressModel[];
  phoneNumbers: IPhoneNumberModel[];
}

export type ContactDataResult = IContactModel[] | null;
