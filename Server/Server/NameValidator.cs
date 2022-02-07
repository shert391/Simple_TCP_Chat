internal class NameValidator
{
    public string Valid(string name, List<Client> clients)
    {
        if (name.Length > 20)
            return "Максимальная длина имени 20 символов!";
        else if (name.Contains(','))
            return "Символ <запятая> запрещён!";
        else if (CheckExistence(clients, name))
            return "Пользователь с таким именем, уже находиться в чате!";
        else
            return "ок";
    }

    private bool CheckExistence(List<Client> clients, string name)
    {
        for (int i = 0; i < clients.Count; i++)
            if (name.Equals(clients[i].Name))
                return true;
        return false;
    }
}

