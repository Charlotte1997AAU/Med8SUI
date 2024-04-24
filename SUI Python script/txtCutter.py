def time_to_seconds(timestamp):
    parts = timestamp.split(',')
    if len(parts) == 1:
        seconds = float(parts[0])  # Convert to float
        milliseconds = 0
    else:
        seconds, milliseconds = map(float, parts)  # Convert both parts to float
    return seconds + milliseconds / 1000  # Convert milliseconds to seconds



def time_difference(t1, t2):
    return abs(time_to_seconds(t2) - time_to_seconds(t1))

def main():
    file_path = "pariticpant 7 non diegetic.txt"  # Replace this with the path to your .txt file
    output_file_path = "time_differences.txt"  # Path to the output file
    with open(file_path, 'r') as file:
        timestamps = file.readlines()

    total_time = 0
    time_diff_list = []
    with open(output_file_path, 'w') as output_file:
        for i in range(len(timestamps) - 1):
            time_diff = time_difference(timestamps[i].strip(), timestamps[i+1].strip())
            total_time += time_diff
            time_diff_list.append(time_diff)
            output_file.write(f"Time between line {i+1} and line {i+2}: {time_diff:.2f} seconds\n")  # Rounded to two decimal points

        average_time_diff = total_time / len(time_diff_list)
        output_file.write(f"\nAverage time difference: {average_time_diff:.2f} seconds\n")  # Rounded to two decimal points

    print(f"Average time difference: {average_time_diff:.2f} seconds")
    print(f"\nTotal time elapsed: {total_time:.2f} seconds")  # Rounded to two decimal points


if __name__ == "__main__":
    main()

