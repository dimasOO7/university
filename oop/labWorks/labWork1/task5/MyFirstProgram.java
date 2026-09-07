import MyFirstPackage.MySecondClass;

class MyFirstClass {
    public static void main(String[] args) {
        MySecondClass secondClass = new MySecondClass(10);
        secondClass.setNumber(0, 500);
        double avg = secondClass.getAvg();
        System.out.println("среднее арифметическое: " + avg);
        secondClass.displayArray();
    }
}
