<script>
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';
</script>

<h1>Phos Music Manager</h1>
<p>
	<em>Phos Music Manager</em> is, well, a music manager. It simplifies replacing music to just selecting
	your new file, setting your loop, and building.
</p>
<h2>Requirements</h2>
<ul>
	<li>
		<Link url="https://dotnet.microsoft.com/en-us/download/dotnet/7.0">.NET 7 Desktop Runtime</Link>
	</li>
	<li><Link url="{base}/guides/create-mod">Created a Music Mod</Link></li>
</ul>
<h2>Getting Started</h2>
<ol>
	<li>
		Download the latest version from here: <Link
			url="https://github.com/T-PoseRatkechi/phos-music-manager/releases"
		/>
		<ul><li>The file you need to download is <b>PhosMusicManager.zip</b>.</li></ul>
	</li>
	<li>Unzip the file then run <b>PhosMusicManager.exe</b>.</li>
</ol>
<h2>Project Setup</h2>
<ul>
	<li>
		<b>Music Replacement:</b> Select the game project for your game. Then click the gear icon near
		the top to open <b>Project Settings</b>.
	</li>
	<li><b>(Recommended) BGME Framework:</b> Select <b>New Project</b>.</li>
	<ul>
		<li>
			Use a new project for <em>BGME Framework</em> mods to separate the game's audio tracks from any
			new ones you add.
		</li>
		<li>Multiple projects can use the same output folder, so there's no conflicts.</li>
	</ul>
</ul>
<ol>
	<li>Under the <b>Output Folder</b> setting, click on the folder icon.</li>
	<li>Go to your music mod's folder, then click <b>Select Folder</b>.</li>
	<ul>
		<li>
			Your music mod, along with all other mods, can be found in the Reloaded II folder: <code
				>RELOADED_II_FOLDER/mods</code
			>
		</li>
	</ul>
	<li>Click <b>Confirm/Create</b> to save changes.</li>
</ol>
<h2>Music Replacement</h2>
<ol>
	<li>Find the song you want to replace and select it.</li>
	<li>In the side menu that opened, select your replacement file.</li>
	<li>Set your loop points.</li>
	<li>Once you're finished replacing any songs, click <b>Build</b> at the top.</li>
</ol>
<h2>BGME Framework</h2>
<p>With <em>BGME Framework</em>, it's likely you'll be adding and using new audio tracks.</p>
<ol>
	<li>In your project, click the <b>+</b> button near the top to add a new track.</li>
	<li>Fill in the name, along with the category and tags if you like.</li>
	<li>
		For the <b>Output Path</b> and <b>Encoder</b>, these will depend on the game you're modding:
	</li>
	<ul>
		<li>
			<b>BGM ID</b>
			<div>
				Replace <code>BGM_ID</code> with the ID you intend to use. For more information see: <Link
					url="{base}/guides/new-music">Using New Music</Link
				>
			</div>
		</li>
		<li>
			<b>Persona 4 Golden</b>
			<div>Output Path: <code>FEmulator/AWB/snd00_bgm.awb/BGM_ID.hca</code></div>
			<div>Encoder: HCA</div>
		</li>
		<li>
			<b>Persona 5 Royal</b>
			<div>Output Path: <code>FEmulator/AWB/BGM_42.AWB/BGM_ID.adx</code></div>
			<div>Encoder: ADX (Persona 5 Royal PC)</div>
		</li>
		<li>
			<b>Persona 3 Portable</b>
			<div>Output Path: <code>P5REssentials/CPK/BGME/data/sound/bgm/BGM_ID.adx</code></div>
			<div>Encoder: ADX</div>
		</li>
	</ul>
	<li>
		Once finished, click <b>Add</b>. Now you can select it, set a replacement file and loop, then
		<b>Build</b> like usual.
	</li>
</ol>
<p>
	<b>Continue: <Link url="{base}/guides/randomized-bgm">Adding Randomized BGM</Link></b>
</p>
