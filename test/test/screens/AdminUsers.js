import React from "react";
import { View, Button, Text, StyleSheet } from "react-native";
import { useState } from "react";
import { ScrollView } from "react-native";
import { TouchableOpacity } from "react-native";

const AdminUsers = () => {
  const [tableData, setTableData] = useState([
    { id: 1, Name: "Test student 1" },
    { id: 2, Name: "Cor student 2" },
    { id: 3, Name: "Patryk Góra" },
    { id: 4, Name: "Uczeń uczniowski" },
    { id: 5, Name: "Michał Corepetytorski" },
  ]);

  return (
    <ScrollView>
      <View style={styles.container}>
        <Text
          style={{
            textAlign: "center",
            fontSize: 30,
            paddingTop: 60,
            flex: 1,
            fontWeight: "600",
            color: "#A40303",
          }}
        >
          Uczniowie
        </Text>

        <View
          style={{
            marginTop: 30,
            marginLeft: 15,
            flex: 1,
            alignSelf: "stretch",
            borderWidth: 2,
            borderColor: "black",
            borderRadius: 15,
            padding: 10,
            marginRight: 8,
            backgroundColor: "white",
            //flexDirection: 'row',
          }}
        >
          <View style={styles.tableHeader}>
            <Text style={styles.headerText}>Imię i nazwisko</Text>
            <Text style={styles.headerText}>Akcja</Text>
          </View>
          {tableData.map((item) => (
            <View key={item.id} style={styles.tableRow}>
              <Text style={styles.rowText}>{item.Name}</Text>
              <View>
                <Button title="Zablokuj" color="#A40303" />
              </View>
            </View>
          ))}
        </View>
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    backgroundColor: "#F8FCD4",
  },
  tableHeader: {
    flexDirection: "row",
    justifyContent: "space-between",
    borderBottomWidth: 1,
    borderColor: "#ccc",
    paddingBottom: 10,
    marginBottom: 10,
    overflow: "scroll",
  },
  headerText: {
    fontWeight: "bold",
    fontSize: 16,
    width: "80%",
  },
  tableRow: {
    flexDirection: "row",
    justifyContent: "space-between",
    borderBottomWidth: 1,
    borderColor: "#ccc",
    paddingBottom: 10,
    marginBottom: 10,
  },
  rowText: {
    fontSize: 16,
    width: "50%",
  },

  statusText: {
    fontSize: 16,
    backgroundColor: "green",
  },
});

export default AdminUsers;
